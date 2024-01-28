<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmSplash
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.lblMain = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.picShowHidePassword = New System.Windows.Forms.PictureBox()
        Me.btnPasswordSubmit = New System.Windows.Forms.Button()
        Me.pnlLogin = New System.Windows.Forms.Panel()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.btnRetry = New System.Windows.Forms.Button()
        CType(Me.picShowHidePassword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlLogin.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(96, 440)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(452, 20)
        Me.txtStatus.TabIndex = 0
        '
        'lblMain
        '
        Me.lblMain.AutoSize = True
        Me.lblMain.BackColor = System.Drawing.Color.Transparent
        Me.lblMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 40.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMain.Location = New System.Drawing.Point(165, 9)
        Me.lblMain.Name = "lblMain"
        Me.lblMain.Size = New System.Drawing.Size(271, 63)
        Me.lblMain.TabIndex = 1
        Me.lblMain.Text = "CatPicker"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 6)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "User Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Password"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(104, 3)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 20)
        Me.txtUsername.TabIndex = 4
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(104, 27)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 5
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'picShowHidePassword
        '
        Me.picShowHidePassword.Image = Global.Start.My.Resources.Resources.passwordEye
        Me.picShowHidePassword.Location = New System.Drawing.Point(210, 27)
        Me.picShowHidePassword.Name = "picShowHidePassword"
        Me.picShowHidePassword.Size = New System.Drawing.Size(20, 20)
        Me.picShowHidePassword.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picShowHidePassword.TabIndex = 6
        Me.picShowHidePassword.TabStop = False
        '
        'btnPasswordSubmit
        '
        Me.btnPasswordSubmit.Location = New System.Drawing.Point(104, 53)
        Me.btnPasswordSubmit.Name = "btnPasswordSubmit"
        Me.btnPasswordSubmit.Size = New System.Drawing.Size(100, 23)
        Me.btnPasswordSubmit.TabIndex = 7
        Me.btnPasswordSubmit.Text = "Run Cat Picker"
        Me.btnPasswordSubmit.UseVisualStyleBackColor = True
        '
        'pnlLogin
        '
        Me.pnlLogin.Controls.Add(Me.btnPasswordSubmit)
        Me.pnlLogin.Controls.Add(Me.picShowHidePassword)
        Me.pnlLogin.Controls.Add(Me.txtPassword)
        Me.pnlLogin.Controls.Add(Me.txtUsername)
        Me.pnlLogin.Controls.Add(Me.Label3)
        Me.pnlLogin.Controls.Add(Me.Label2)
        Me.pnlLogin.Location = New System.Drawing.Point(176, 283)
        Me.pnlLogin.Name = "pnlLogin"
        Me.pnlLogin.Size = New System.Drawing.Size(284, 80)
        Me.pnlLogin.TabIndex = 8
        '
        'lblWarning
        '
        Me.lblWarning.BackColor = System.Drawing.Color.Transparent
        Me.lblWarning.ForeColor = System.Drawing.Color.DarkRed
        Me.lblWarning.Location = New System.Drawing.Point(442, 19)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(231, 53)
        Me.lblWarning.TabIndex = 20
        Me.lblWarning.Text = "To read Cat data from api:  " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Run C:\Users\Ken\source\repos\" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "EmployeesAPI\Employ" &
    "eesAPI\EmployeesAPI. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Change repository data source in CatBLL" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.lblWarning.Visible = False
        '
        'btnRetry
        '
        Me.btnRetry.Location = New System.Drawing.Point(292, 365)
        Me.btnRetry.Name = "btnRetry"
        Me.btnRetry.Size = New System.Drawing.Size(75, 50)
        Me.btnRetry.TabIndex = 21
        Me.btnRetry.Text = "Retry Running Cat Picker"
        Me.btnRetry.UseVisualStyleBackColor = True
        '
        'frmSplash
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.Start.My.Resources.Resources.catPickerSplash
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(670, 472)
        Me.Controls.Add(Me.btnRetry)
        Me.Controls.Add(Me.lblWarning)
        Me.Controls.Add(Me.pnlLogin)
        Me.Controls.Add(Me.lblMain)
        Me.Controls.Add(Me.txtStatus)
        Me.Name = "frmSplash"
        Me.Text = "Splash"
        Me.ToolTip1.SetToolTip(Me, "Show/Hide Password")
        CType(Me.picShowHidePassword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlLogin.ResumeLayout(False)
        Me.pnlLogin.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtStatus As TextBox
    Friend WithEvents lblMain As Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtUsername As TextBox
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents picShowHidePassword As PictureBox
    Friend WithEvents btnPasswordSubmit As Button
    Friend WithEvents pnlLogin As Panel
    Friend WithEvents lblWarning As Label
    Friend WithEvents btnRetry As Button
End Class
