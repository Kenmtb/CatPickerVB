Imports Models
Imports System.Data.SqlClient

Public Class StoredProcRep '(Of T)
  Inherits ODBCRep(Of StoredProc)

  Public Sub New()
    MyBase.conStrName = "CatsContext"
    MyBase.createSQLstrings("dbo.spGetCatsBy_Age_Breed_Gender")
  End Sub

  Function runSP(spName As String, spParams As List(Of (String, String))) As DataTable

    'Set up and call search SP    
    Dim sqlCon = MyBase.getConnection
    Dim dt As DataTable

    Using (sqlCon)

      Dim sqlComm As New SqlCommand()

      sqlComm.Connection = sqlCon

      sqlComm.CommandText = spName '"spGetCatsBy_Age_Breed_Gender"
      sqlComm.CommandType = CommandType.StoredProcedure

      'Get parameters

      If spParams IsNot Nothing Then
        For Each parm As ValueTuple(Of String, String) In spParams
          If parm.Item2 = "" Then parm.Item2 = Nothing
          sqlComm.Parameters.AddWithValue(parm.Item1, parm.Item2)
        Next
      End If

      'Get the data
      Dim sqlReader As SqlDataReader = sqlComm.ExecuteReader()

      If sqlReader.HasRows Then
        dt = New DataTable()
        dt.Load(sqlReader)

        For Each dr As DataRow In dt.Rows
          'Dim breedId As Integer = If(Not IsDBNull(dr("breedId")), DirectCast(dr("breedId"), Integer?), Nothing)
          'Dim age As Integer = If(Not IsDBNull(dr("age")), DirectCast(dr("age"), Nullable(Of Integer)), Nothing)
          'Dim gender As String = dr("gender").ToString()
        Next
        Return dt
      End If
    End Using
    Return Nothing
  End Function

  Function spInsert(spName As String, spParams As List(Of (String, String))) As DataTable

    'Set up and call search SP    
    Dim sqlCon = MyBase.getConnection
    Dim dt As DataTable

    Using (sqlCon)

      Dim sqlComm As New SqlCommand()

      sqlComm.Connection = sqlCon

      sqlComm.CommandText = spName '"spGetCatsBy_Age_Breed_Gender"
      sqlComm.CommandType = CommandType.StoredProcedure

      'Get parameters

      If spParams IsNot Nothing Then
        For Each parm As ValueTuple(Of String, String) In spParams
          If parm.Item2 = "" Then parm.Item2 = Nothing
          sqlComm.Parameters.AddWithValue(parm.Item1, parm.Item2)
        Next
      End If

      'Get the data
      Dim sqlReader As SqlDataReader = sqlComm.ExecuteReader()

      If sqlReader.HasRows Then
        dt = New DataTable()
        dt.Load(sqlReader)

        For Each dr As DataRow In dt.Rows
          'Dim breedId As Integer = If(Not IsDBNull(dr("breedId")), DirectCast(dr("breedId"), Integer?), Nothing)
          'Dim age As Integer = If(Not IsDBNull(dr("age")), DirectCast(dr("age"), Nullable(Of Integer)), Nothing)
          'Dim gender As String = dr("gender").ToString()
        Next
        Return dt
      End If
    End Using
    Return Nothing
  End Function



  'Function runParameterSP(spParams As List(Of ValueTuple(Of String, String))) As T

  ''Set up and call search SP    
  'Dim sqlCon = MyBase.getConnection
  'Dim dt As DataTable

  'Using (sqlCon)

  '  Dim sqlComm As New SqlCommand()

  '  sqlComm.Connection = sqlCon

  '  sqlComm.CommandText = "spGetCatsBy_Age_Breed_Gender"
  '  sqlComm.CommandType = CommandType.StoredProcedure

  'Get parameters

  'sqlComm.Parameters.AddWithValue(spParams(0).Item1, spParams(0).Item2)
  'sqlComm.Parameters.AddWithValue(spParams(1).Item1, spParams(1).Item2)
  'sqlComm.Parameters.AddWithValue(spParams(2).Item1, spParams(2).Item2)

  'sqlComm.Parameters.AddWithValue(spParams(0).Item1, Nothing)
  '  sqlComm.Parameters.AddWithValue(spParams(1).Item1, Nothing)
  '  sqlComm.Parameters.AddWithValue(spParams(2).Item1, "4")

  '  'Get the data
  '  Dim sqlReader As SqlDataReader = sqlComm.ExecuteReader()

  '  If sqlReader.HasRows Then

  '    dt = New DataTable()
  '    dt.Load(sqlReader)

  '    For Each dr As DataRow In dt.Rows
  '      Dim breedId As Integer = If(Not IsDBNull(dr("breedId")), DirectCast(dr("breedId"), Integer?), Nothing)
  '      Dim age As Integer = If(Not IsDBNull(dr("age")), DirectCast(dr("age"), Nullable(Of Integer)), Nothing)
  '      Dim gender As String = dr("gender").ToString()
  '    Next


  '  End If

  'End Using

  'End Function

  'Public Overridable Function getParameters(reader As DataRow) As T
  '  Return Nothing
  'End Function


End Class
