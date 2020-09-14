'Nicholas Moore (700566742) Final
'Visual Basic .NET Final Project

Option Explicit On
Option Strict On
Option Infer Off

Public Class Form1
    Public telephone As String
    Public membershipID As Integer
    Public i As Integer = 0

    'Member Structure
    Public Structure Member
        Public lastName, 'Checked
                firstName, 'Checked
                telephone, 'Checked
                planType, 'Checked Single/Family
                status,
                membID As String
    End Structure

    'Struct Array
    Public Memberships(100) As Member

    'Form Load 
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    
    End Sub

    'Calculates Total
    Private Sub btnCalculateMonthlyFee_Click(sender As Object, e As EventArgs) Handles btnCalculateMonthlyFee.Click

        'Variables
        Dim planCost As Integer
        'Create Loop To Iterate Through Members'
        Memberships(i).firstName = txtFirstName.Text
        Memberships(i).lastName = txtLastName.Text
        telephone = txtPhoneNumber.Text

        If (telephone.Length = 10) Then
            Memberships(i).telephone = txtPhoneNumber.Text
            Memberships(i).membID = Memberships(i).telephone
        End If

        'Use as searchbox
        'Integer.TryParse(Memberships(0).telephone, membershipID)

        'Single Plan
        If rdbSingle.Checked Then
            Memberships(i).planType = "Single"
            planCost = planCost + 50
            'Family Plan
        ElseIf rdbFamily.Checked Then
            Memberships(i).planType = "Family"
            planCost = planCost + 90
        End If

        'Single Monthly Charges
        If chkTennis.Checked And Memberships(i).planType = "Single" Then
            planCost = planCost + 30
        End If
        If chkGolf.Checked And Memberships(i).planType = "Single" Then
            planCost = planCost + 25
        End If
        If chkRacquetball.Checked And Memberships(i).planType = "Single" Then
            planCost = planCost + 20
        End If

        'Family Monthly Charges
        If chkTennis.Checked And Memberships(i).planType = "Family" Then
            planCost = planCost + 50
        End If
        If chkGolf.Checked And Memberships(i).planType = "Family" Then
            planCost = planCost + 35
        End If
        If chkRacquetball.Checked And Memberships(i).planType = "Family" Then
            planCost = planCost + 30
        End If
        'Total Cost
        txtMonthlyBill.Text = planCost.ToString("c2")
    End Sub

    'Sign-up Button (Adds Member to List)
    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click

        'Checks Correctness of Phone-Number
        ''Dim loopMe as Integer = 2
        ''while 1 < 2
             ''If Memberships(i).telephone.length = 10 AND Memberships(i).membID = Memberships(i).membID Then 
             ''MessageBox.Show("Sorry Phone Number Is Already In Use")
             ''Exit While
             ''End If
        ''End While
        ''txtPhoneNumber.Focus()
       
        
        While 1 < 2
            If telephone.Length < 10 Or telephone.Length > 10 Then
                MessageBox.Show("Phone Number Must Contain 10 Digit Sequence Ex:ZZZXXXYYYY", "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop)

                txtPhoneNumber.Text = String.Empty
                txtPhoneNumber.Focus()
                Exit While 
            ElseIf telephone.Length = 10 Then
                lstMemberships.Items.Add(Memberships(i).firstName)
                ''falseInfo = True
                txtFirstName.Text = String.Empty
                txtLastName.Text = String.Empty
                txtPhoneNumber.Text = String.Empty
                rdbSingle.Checked = False
                rdbFamily.Checked = False
                chkTennis.Checked = False
                chkGolf.Checked = False
                chkRacquetball.Checked = False
                chkNone.Checked = False
                txtMonthlyBill.Text = String.Empty
                i = i + 1
                lblMemberCounter.Text = "Members: x" + i.ToString()
                Memberships(i).status = "New Member"
                txtFirstName.Focus()
                Exit While
            End If
            txtPhoneNumber.Focus()
        End While
        txtPhoneNumber.Focus()
    End Sub

    'Clear Button
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtFirstName.Text = String.Empty
        txtLastName.Text = String.Empty
        txtPhoneNumber.Text = String.Empty
        rdbSingle.Checked = False
        rdbFamily.Checked = False
        chkTennis.Checked = False
        chkGolf.Checked = False
        chkRacquetball.Checked = False
        chkNone.Checked = False
        txtMonthlyBill.Text = String.Empty
        txtFirstName.Focus()
    End Sub

    'Terminate Membership
    Private Sub btnTerminate_Click(sender As Object, e As EventArgs) Handles btnTerminate.Click
        lstMemberships.Items.RemoveAt(lstMemberships.SelectedIndex())
        i = i - 1
        lblMemberCounter.Text = "Members: x" + i.ToString()
    End Sub

    'Renew Membership
    Private Sub btnRenew_Click(sender As Object, e As EventArgs) Handles btnRenew.Click
        Dim buttonResult As Integer = (MessageBoxButtons.YesNoCancel)

        MessageBox.Show("Are You Sure You Would Like To Renew Your Membership", "Error",
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question)
        If buttonResult = DialogResult.Yes Then
            lstMemberships.SelectedItem = Memberships(i).status = "Renewed Membership"
            MessageBox.Show(Memberships(i).status)
        End If
    End Sub

    'Displays Info
    Private Sub btnDisplay_Click(sender As Object, e As EventArgs) Handles btnDisplay.Click
        lstMemberships.SelectedItem = MessageBox.Show(Memberships(i).status)
    End Sub

    'Exit Button (Closes Program)
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

End Class
