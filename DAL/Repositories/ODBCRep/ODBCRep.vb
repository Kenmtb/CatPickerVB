Imports System.Data
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.Configuration
Imports Globals

Public Class ODBCRep(Of T)

  Private baseSQLString As String
  Private baseSQLDeleteString As String
  Private baseSQLIdString As String
  Private baseSQLGetLastRecordString As String
  Private baseSQLGetLastRecordIDString As String

  Public Property conStrName As String

  Public Sub New()
    'Dim con As SqlConnection
    SqlConnection.ClearAllPools()
    'con.Close()
  End Sub

  '********************************* ADO connection abstract methods

  Public Sub createSQLstrings(tablename As String)
    baseSQLString = "SELECT * FROM " + tablename
    baseSQLDeleteString = "DELETE FROM " + tablename + " where Id = "
    baseSQLIdString = "SELECT * FROM " + tablename + " where Id = "
    baseSQLGetLastRecordIDString = " SELECT max(id) from " + tablename

    'SQL for child tables
    baseSQLGetLastRecordString = " SELECT max(id) from " + tablename 'adding child table data
  End Sub


  Public Function getConnectionString() As String
    Return GetConnectionStringByName(conStrName)
  End Function

  Public Function getConnection() As SqlConnection
    Dim con = New SqlConnection(getConnectionString())
    If con.State = ConnectionState.Closed Then
      con.Open()
    End If
    Return con
  End Function

  Public Function getCommand(Optional ByVal sqlStr As String = Nothing, Optional ByRef paramList As List(Of SqlParameter) = Nothing) As SqlCommand
    'Public Function getCommand(Optional ByVal sqlStr As String = Nothing, Optional ByRef paramList As List(Of Object) = Nothing) As SqlCommand
    Dim com = New SqlCommand()
    com.Connection = getConnection()
    If sqlStr = Nothing Then
      com.CommandText = baseSQLString
    Else
      com.CommandText = sqlStr
    End If

    If paramList IsNot Nothing Then
      For Each param As SqlParameter In paramList
        com.Parameters.Add(param)
      Next
    End If

    Return com
  End Function

  Public Function getCommandString(Optional ByVal sqlStr As String = Nothing, Optional ByRef paramList As List(Of SqlParameter) = Nothing)
    'Public Function getCommandString(Optional ByVal sqlStr As String = Nothing, Optional ByRef paramList As List(Of Object) = Nothing)
    Dim con As SqlConnection = getConnection()
    Dim cmd As SqlCommand = getCommand(sqlStr, paramList)
    Return cmd
  End Function

  Public Function GetConnectionStringByName(name As String)
    'Assume failure
    Dim returnValue As String = Nothing

    'Look for the name in the connection string section
    Dim settings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(name)

    'If found, return the connection string
    If settings IsNot Nothing Then
      returnValue = settings.ConnectionString
    End If

    Return returnValue
  End Function
  '*********************************************** CRUD helpers
  Public Function getDataObject(Optional ByVal sqlStr As String = Nothing, Optional ByRef paramList As List(Of SqlParameter) = Nothing)
    'Public Function getDataObject(Optional ByVal sqlStr As String = Nothing, Optional ByRef paramList As List(Of Object) = Nothing)
    Dim dt As New DataTable()
    'Dim cmd As SqlCommand()
    'Dim sdr As SqlDataReader()

    Using cmd As SqlCommand = getCommand(sqlStr, paramList)
      Using sdr As SqlDataReader = cmd.ExecuteReader()
        'Using dt As New DataTable()
        dt.Load(sdr)
        Return dt
        'End Using
      End Using
    End Using
  End Function

  'Public Function getDataObject(spName As String, spParams As List(Of ValueTuple(Of String, String)))
  Public Function getDataObject(spName As String, spParams As List(Of (String, String)))
    'SP
    Dim sqlCon = getConnection()
    Dim dt As New DataTable
    Dim cmd As New SqlCommand()

    cmd.Connection = getConnection()

    cmd.CommandText = spName '"spGetCatsBy_Age_Breed_Gender"
    cmd.CommandType = CommandType.StoredProcedure

    For Each parm As ValueTuple(Of String, String) In spParams
      If parm.Item2 = "" Then parm.Item2 = Nothing
      cmd.Parameters.AddWithValue(parm.Item1, parm.Item2)
    Next

    Using cmd
      Using sdr As SqlDataReader = cmd.ExecuteReader()
        'Using dt As New DataTable()
        dt.Load(sdr)
        Return dt
        'End Using
      End Using
    End Using

  End Function

  'Protected Function getRecords(spName As String, spParams As List(Of ValueTuple(Of String, String))) As IEnumerable(Of T)
  Protected Function getRecords(spName As String, spParams As List(Of (String, String))) As IEnumerable(Of T)
    'Protected Function getRecords(spName As String, spParams As List(Of Object)) As IEnumerable(Of T)
    'Get records from SP

    Dim list = New List(Of T)()
    Dim reader As DataTable = Nothing

    'reader = getSPDataObject(spParams)
    reader = getDataObject(spName, spParams)

    Try
      If reader.Rows.Count > 0 Then
        For Each rec As DataRow In reader.Rows
          list.Add(populateRecord(rec))
        Next
      End If
    Catch ex As Exception
      Throw New Globals.CustomException("Record fetch failed. (check repository model mapping for missing or misspelled fields or null data)")
    End Try
    Return list

  End Function


  Public Overridable Function populateRecord(reader As DataRow) As T
    Return Nothing
  End Function

  Protected Function getRecordByID(Id As Integer) As T
    Return Nothing
  End Function


  Protected Function getRecords() As IEnumerable(Of T)
    'Protected Function getRecords(Optional ByVal sqlStr As String = Nothing, Optional ByRef paramList As List(Of SqlParameter) = Nothing) As IEnumerable(Of T)

    Dim list = New List(Of T)()
    Dim reader As DataTable = Nothing

    reader = getDataObject()

    Try
      If reader.Rows.Count > 0 Then
        For Each rec As DataRow In reader.Rows
          list.Add(populateRecord(rec))
        Next
      End If
    Catch ex As Exception
      Throw New Globals.CustomException("Record fetch failed. (check repository model mapping for missing or misspelled fields or null data)")
    End Try
    Return list

  End Function

  Protected Sub saveRecords(rec As T, id As String)

    Try
      Dim cmd As SqlCommand
      cmd = getCommand((baseSQLIdString + id))
      Dim da As New SqlDataAdapter(cmd)
      Dim dt As New DataTable()
      da.Fill(dt)

      Dim dr As DataRow = dt.Rows(0)
      dr = populateDataRow(rec, dr)

      Dim cb As New SqlCommandBuilder(da)
      da.Update(dt)

    Catch ex As Exception
      Throw New Globals.CustomException("Save changes failed, check editor for invalid or missing entries.")
    End Try

  End Sub

  Protected Sub insertRecords(rec As T)
    Try
      Dim cmd As SqlCommand
      cmd = getCommand(baseSQLString)
      Dim da As New SqlDataAdapter(cmd)
      Dim dt As New DataTable()
      da.Fill(dt)

      Dim dr As DataRow = dt.Rows(0)
      dr = populateDataRow(rec, dr)

      Dim cb As New SqlCommandBuilder(da)
      'Add new record
      da.UpdateCommand = cb.GetInsertCommand()
      da.Update(dt)

    Catch ex As Exception
      Throw New Globals.CustomException("Update changes failed, check editor for invalid or missing entries.")
    End Try
  End Sub


  Public Function delete(id As Object)
    Try
      Dim cmd As SqlCommand
      cmd = getCommand(baseSQLDeleteString + id)
      Dim da As New SqlDataAdapter(cmd)
      Dim dt As New DataTable()
      da.Fill(dt)

      Dim dr As DataRow = dt.Rows(0)

      dr.Delete()
      da.Update(dt)

    Catch ex As Exception
      Throw New Globals.CustomException("Delete changes failed, check editor for invalid or missing entries.")
    End Try
  End Function

  Public Overridable Function populateDataRow(datarec As T, dr As DataRow) As DataRow
    Return Nothing
  End Function

End Class


