Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient

Public Class Form1

#Region "declare"
    Dim mycmd As New MySqlCommand
    Dim myconnection As New DBConnection
    Dim mycmd2 As New MySqlCommand
    Dim myconnection2 As New DBConnection
    Dim objreader As MySqlDataReader
    Dim objreader2 As MySqlDataReader
#End Region

    Dim HH As Integer
    Dim LineNumber As Integer
    Dim LinePerpAge As Integer
    Dim I_Start As Integer
    Dim I_Counter As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            tbci.Items.Clear()
            mycmd.Connection = myconnection.open
            mycmd.CommandText = "select * from tbCategory"
            objreader = mycmd.ExecuteReader
            While objreader.Read
                tbci.Items.Add(objreader.Item("Category").ToString)
                tbcat.Items.Add(objreader.Item("Category").ToString)
            End While
            tbci.Items.Add("")
            myconnection.close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try

        Try
            cbtm.Items.Clear()
            mycmd.Connection = myconnection.open
            mycmd.CommandText = "select * from tbmedicineandsupplies Where Balance !=0 Group By MedAndMat"
            objreader = mycmd.ExecuteReader
            While objreader.Read
                cbtm.Items.Add(objreader.Item("MedAndMat").ToString)
            End While
            cbtm.Items.Add("")
            myconnection.close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try

        Try
            Dim isi As ListViewItem
            LV.Items.Clear()
            mycmd.Connection = myconnection.open
            mycmd.CommandText = "select * from tbpatient WHERE DATETIME >= '" + Format(Date.Today(), "yyyy-MM-dd") + "'"
            objreader = mycmd.ExecuteReader
            While objreader.Read
                isi = LV.Items.Add(objreader.Item("id").ToString)
                isi.SubItems.Add(objreader.Item("DATETIME").ToString)
                isi.SubItems.Add(objreader.Item("NAME").ToString)
                isi.SubItems.Add(objreader.Item("YEARSECTION").ToString)
                isi.SubItems.Add(objreader.Item("COMPLAINTSIMPRESSION").ToString)
                isi.SubItems.Add(objreader.Item("TREATMENTMEDICINES").ToString)
            End While
            myconnection.close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try



        MS.Hide()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tbname.Text = ""
        cbp.Text = "BSIT"
        cby.Text = "1"
        cbs.Text = "1"
        tbci.Text = ""
        cbtm.SelectedIndex = -1
        cbmsp.SelectedIndex = -1

        Form1_Load(e, e)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

        Dim Date1 As Date = DateTimePicker1.Value
        Dim Date2 As Date = DateTimePicker2.Value.AddDays(1)

        Try
            Dim isi As ListViewItem
            LV.Items.Clear()
            mycmd.Connection = myconnection.open
            mycmd.CommandText = "select * from tbpatient WHERE DATETIME >= '" + Format(Date1, "yyyy-MM-dd") + "' AND DATETIME <= '" + Format(Date2, "yyyy-MM-dd") + "'"
            objreader = mycmd.ExecuteReader
            While objreader.Read
                isi = LV.Items.Add(objreader.Item("id").ToString)
                isi.SubItems.Add(objreader.Item("DATETIME").ToString)
                isi.SubItems.Add(objreader.Item("NAME").ToString)
                isi.SubItems.Add(objreader.Item("YEARSECTION").ToString)
                isi.SubItems.Add(objreader.Item("COMPLAINTSIMPRESSION").ToString)
                isi.SubItems.Add(objreader.Item("TREATMENTMEDICINES").ToString)
            End While
            myconnection.close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tbname.Text = ""
        cbp.Text = "BSIT"
        cby.Text = "1"
        cbs.Text = "1"
        tbci.Text = ""
        cbtm.SelectedIndex = -1
        cbmsp.SelectedIndex = -1

        Button9_Click(e, e)
        MS.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MS.Hide()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Dim Insert As String = "False"

        If tbname.Text = "" Then
            MessageBox.Show("Student Name is Required")
        ElseIf tbci.Text = "" Then
            MessageBox.Show("Please enter your Complaints/Impression")
        Else
            If cbtm.Text = "" Then
                Insert = "True"
            Else
                Try
                    mycmd.Connection = myconnection.open
                    mycmd.CommandText = "select * from tbmedicineandsupplies WHERE MedAndMat = '" + cbtm.Text + "' AND BALANCE >= " + cbmsp.Text + " Limit 1"
                    objreader = mycmd.ExecuteReader
                    If objreader.Read Then
                        Dim Consumed As Integer = objreader.Item("CONSUMED") + cbmsp.Text
                        Dim NewBalance As Integer = objreader.Item("BALANCE") - cbmsp.Text
                        mycmd2.Connection = myconnection2.open
                        mycmd2.CommandText = "UPDATE `tbmedicineandsupplies` SET `CONSUMED` = '" & Consumed.ToString() & "', `BALANCE` = '" & NewBalance.ToString() & "'
                    WHERE `tbmedicineandsupplies`.`id` = " & objreader.Item("id").ToString() & ";"
                        mycmd2.ExecuteNonQuery()
                        myconnection2.close()
                        Insert = "True"
                    Else
                        MessageBox.Show("Out Of Balance for " + cbtm.Text)
                        Insert = "False"
                    End If
                    myconnection.close()
                Catch ex As MySqlException
                    MessageBox.Show(ex.Message)
                    myconnection.close()
                End Try
            End If

            If Insert = "True" Then
                Try
                    mycmd.Connection = myconnection.open
                    mycmd.CommandText = "insert into tbpatient(NAME, YEARSECTION, COMPLAINTSIMPRESSION, TREATMENTMEDICINES)
                    values ('" & tbname.Text & "','" & cbp.Text + " " + cby.Text + "-" + cbs.Text & "','" & tbci.Text & "','" & cbtm.Text & "')"
                    mycmd.ExecuteNonQuery()
                    myconnection.close()
                    MsgBox("Student Added to the Record Successfuly!", MsgBoxStyle.Information, "Notice..")
                Catch ex As MySqlException
                    MessageBox.Show(ex.Message)
                    myconnection.close()
                End Try
            End If

            tbname.Text = ""
            cbp.Text = "BSIT"
            cby.Text = "1"
            cbs.Text = "1"
            tbci.Text = ""
            cbtm.SelectedIndex = -1
            cbmsp.SelectedIndex = -1

            Form1_Load(e, e)
        End If
    End Sub

    Private Sub LV2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LV2.SelectedIndexChanged
        Try
            mycmd.Connection = myconnection.open
            mycmd.CommandText = "select * from tbmedicineandsupplies WHERE id = " + LV2.FocusedItem.Text
            objreader = mycmd.ExecuteReader
            While objreader.Read
                tbid.Text = objreader.Item("id")
                tbcat.Text = objreader.Item("Category")
                tbmed.Text = objreader.Item("MedAndMat")
                tbquan.Text = objreader.Item("QUANTITY")
                tbcon.Text = objreader.Item("CONSUMED")
                tbbal.Text = objreader.Item("BALANCE")
                tbunit.Text = objreader.Item("UNIT")
            End While
            myconnection.close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try

        If LV2.FocusedItem.Text = "0" Then
            tbid.Text = ""
            tbcat.Text = ""
            tbmed.Text = ""
            tbquan.Text = ""
            tbcon.Text = ""
            tbbal.Text = ""
            tbunit.Text = ""
        End If

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles SearchBox.TextChanged
        Try
            Dim isi As ListViewItem
            LV2.Items.Clear()
            mycmd.Connection = myconnection.open
            mycmd.CommandText = "select * from tbmedicineandsupplies WHERE CONCAT(DATE,MedAndMat,Quantity, Consumed, Balance, Unit) like '%" + SearchBox.Text + "%'"
            objreader = mycmd.ExecuteReader
            While objreader.Read
                Dim datee As String = objreader.Item("DATE").ToString
                isi = LV2.Items.Add(objreader.Item("id").ToString)
                isi.SubItems.Add(datee)
                isi.SubItems.Add(objreader.Item("MedAndMat").ToString)
                isi.SubItems.Add(objreader.Item("QUANTITY").ToString + " " + objreader.Item("UNIT").ToString)
                If objreader.Item("CONSUMED").ToString = 0 Then
                    isi.SubItems.Add(objreader.Item("CONSUMED").ToString)
                Else
                    isi.SubItems.Add(objreader.Item("CONSUMED").ToString + " " + objreader.Item("UNIT").ToString)
                End If
                isi.SubItems.Add(objreader.Item("BALANCE").ToString + " " + objreader.Item("UNIT").ToString)
            End While
            myconnection.close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Try
            Dim isi As ListViewItem
            LV2.Items.Clear()
            LV2.View = View.Details
            mycmd2.Connection = myconnection2.open
            mycmd2.CommandText = "select * from tbcategory"
            objreader2 = mycmd2.ExecuteReader
            While objreader2.Read
                isi = LV2.Items.Add("0")
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi = LV2.Items.Add("0")
                isi.SubItems.Add("")
                isi.SubItems.Add(objreader2.Item("NO").ToString + ". " + objreader2.Item("category").ToString)
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                isi.SubItems.Add("")
                News(objreader2.Item("category").ToString)
            End While
            myconnection2.close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try

        tbbal.Text = ""
        tbquan.Text = ""
        tbmed.Text = ""
        tbcon.Text = ""
        tbid.Text = ""
        tbcat.Text = ""
        tbunit.Text = ""
        LinePerpAge = 30
    End Sub

    Public Sub News(n As String)
        Try
            Dim isi As ListViewItem
            mycmd.Connection = myconnection.open
            mycmd.CommandText = "select * from tbmedicineandsupplies Where category = '" + n + "'"
            objreader = mycmd.ExecuteReader
            While objreader.Read
                Dim datee As String = objreader.Item("DATE").ToString
                isi = LV2.Items.Add(objreader.Item("id").ToString)
                isi.SubItems.Add(datee)
                isi.SubItems.Add(objreader.Item("MedAndMat").ToString)
                isi.SubItems.Add(objreader.Item("QUANTITY").ToString + " " + objreader.Item("UNIT").ToString)
                If objreader.Item("CONSUMED").ToString = 0 Then
                    isi.SubItems.Add(objreader.Item("CONSUMED").ToString)
                Else
                    isi.SubItems.Add(objreader.Item("CONSUMED").ToString + " " + objreader.Item("UNIT").ToString)
                End If
                isi.SubItems.Add(objreader.Item("BALANCE").ToString + " " + objreader.Item("UNIT").ToString)
            End While

            myconnection.close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Try
            If tbmed.Text = "" Then
                MsgBox("Medicine/Materilas are Required, Data not Saved!", MsgBoxStyle.Information, "Notice..")
            Else
                mycmd.Connection = myconnection.open
                mycmd.CommandText = "UPDATE `tbmedicineandsupplies` SET `DATE` = '" + Format(Date.Today, "yyyy-MM-dd") + "',`Category` = '" & tbcat.Text & "', `MedAndMat` = '" & tbmed.Text & "', `CONSUMED` = '" & tbcon.Text & "', 
                                `BALANCE` = '" & tbbal.Text & "', `QUANTITY` = '" & tbquan.Text & "', `UNIT` = '" & tbunit.Text & "'
                                WHERE `tbmedicineandsupplies`.`id` = " & tbid.Text & ";"
                mycmd.ExecuteNonQuery()
                myconnection.close()

                MsgBox("Medicine/Materilas Updated Successfuly!", MsgBoxStyle.Information, "Notice..")
            End If


        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try

        tbbal.Text = ""
        tbquan.Text = ""
        tbmed.Text = ""
        tbcon.Text = ""
        tbid.Text = ""
        tbcat.Text = ""
        tbunit.Text = ""

        Button9_Click(e, e)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click

        Try
            If tbmed.Text = "" Then
                MsgBox("Medicine/Materials are Required, Data not Saved!", MsgBoxStyle.Information, "Notice..")
            ElseIf tbquan.Text = "" Then
                MsgBox("Medicine/Materials Quantity are Required, Data not Saved!", MsgBoxStyle.Information, "Notice..")
            Else
                mycmd.Connection = myconnection.open
                mycmd.CommandText = "insert into tbmedicineandsupplies(DATE, CATEGORY, MedAndMat, QUANTITY, CONSUMED, BALANCE, UNIT)
                    values ('" & Format(Date.Today, "yyyy-MM-dd") & "','" & tbcat.Text & "','" & tbmed.Text & "','" & tbquan.Text & "','" + tbcon.Text & "','" & tbquan.Text & "','" & tbunit.Text & "')"
                mycmd.ExecuteNonQuery()
                myconnection.close()

                MsgBox("Medicine/Materilas Added Successfuly!", MsgBoxStyle.Information, "Notice..")
            End If


        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try

        tbbal.Text = ""
        tbquan.Text = ""
        tbmed.Text = ""
        tbcon.Text = ""
        tbid.Text = ""
        tbcat.Text = ""
        tbunit.Text = ""

        Button9_Click(e, e)

    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click

        If LV2.SelectedItems.Count > 0 Then
            If LV2.FocusedItem.Text = "0" Then
                MsgBox("Selected Item cannot be deleted!", MsgBoxStyle.Information, "Notice..")
            Else
                Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButtons.YesNo)
                If (result = DialogResult.Yes) Then
                    mycmd.Connection = myconnection.open
                    mycmd.CommandText = "DELETE FROM `tbmedicineandsupplies` WHERE `tbmedicineandsupplies`.`id` = " + LV2.FocusedItem.Text
                    mycmd.ExecuteNonQuery()
                    myconnection.close()
                    MsgBox("Medicine/Materilas Deleted Successfuly!", MsgBoxStyle.Information, "Notice..")
                    Button9_Click(e, e)
                End If
            End If
        Else
            MessageBox.Show("Select Medicine/Materials To delete!")
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If LV.SelectedItems.Count > 0 Then
            Dim result As DialogResult = MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButtons.YesNo)
            If (result = DialogResult.Yes) Then
                mycmd.Connection = myconnection.open
                mycmd.CommandText = "DELETE FROM `tbpatient` WHERE `tbpatient`.`id` = " + LV.FocusedItem.Text
                mycmd.ExecuteNonQuery()
                myconnection.close()
                MsgBox("Studenr Record Deleted Successfuly!", MsgBoxStyle.Information, "Notice..")
                Button9_Click(e, e)
            End If
        Else
            MessageBox.Show("Select Student Record To delete!")
        End If

        Form1_Load(e, e)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        PrintDialog2.Document = PrintDocument2
        If PrintDialog2.ShowDialog = DialogResult.OK Then
            PrintDialog2.PrinterSettings = PrintDocument2.PrinterSettings
            Dim Mew_Paper As New PaperSize("", 3300, 2550)
            Mew_Paper.PaperName = PaperKind.Custom
            Dim New_margin As New Margins
            New_margin.Left = 0
            New_margin.Top = 50

            With PrintDocument2
                .DefaultPageSettings.PaperSize = Mew_Paper
                .DefaultPageSettings.Margins = New_margin
                .PrinterSettings.DefaultPageSettings.Landscape = True
                .Print()
            End With
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        HH = 30
        e.Graphics.DrawString("DAILY TREATMENT RECORD", New Drawing.Font("Times New Roman", 30), Brushes.Black, 120, HH)
        HH += 80
        e.Graphics.DrawLine(Pens.Black, 30, HH, 820, HH)
        e.Graphics.DrawString("DATE/TIME", New Drawing.Font("Times New Roman", 12), Brushes.Black, 45, HH + 5)
        e.Graphics.DrawString("NAME", New Drawing.Font("Times New Roman", 12), Brushes.Black, 230, HH + 5)
        e.Graphics.DrawString("YEAR/", New Drawing.Font("Times New Roman", 10), Brushes.Black, 355, HH)
        e.Graphics.DrawString("SECTION", New Drawing.Font("Times New Roman", 10), Brushes.Black, 370, HH + 15)
        e.Graphics.DrawString("COMPLAINTS/", New Drawing.Font("Times New Roman", 10), Brushes.Black, 475, HH)
        e.Graphics.DrawString("IMPRESSION", New Drawing.Font("Times New Roman", 10), Brushes.Black, 515, HH + 15)
        e.Graphics.DrawString("TREATMENT/", New Drawing.Font("Times New Roman", 10), Brushes.Black, 670, HH)
        e.Graphics.DrawString("MEDICINES", New Drawing.Font("Times New Roman", 10), Brushes.Black, 695, HH + 15)
        HH += 30
        Dim NN As Integer
        NN = HH
        e.Graphics.DrawLine(Pens.Black, 30, NN, 820, NN)

        For Me.I_Counter = I_Start To LV.Items.Count - 1
            e.Graphics.DrawString(LV.Items(I_Counter).SubItems(1).Text, New Drawing.Font("Times New Roman", 9), Brushes.Black, 32, HH + 5)
            e.Graphics.DrawString(LV.Items(I_Counter).SubItems(2).Text, New Drawing.Font("Times New Roman", 9), Brushes.Black, 172, HH + 5)
            e.Graphics.DrawString(LV.Items(I_Counter).SubItems(3).Text, New Drawing.Font("Times New Roman", 9), Brushes.Black, 342, HH + 5)
            e.Graphics.DrawString(LV.Items(I_Counter).SubItems(4).Text, New Drawing.Font("Times New Roman", 9), Brushes.Black, 442, HH + 5)
            e.Graphics.DrawString(LV.Items(I_Counter).SubItems(5).Text, New Drawing.Font("Times New Roman", 9), Brushes.Black, 632, HH + 5)
            HH += 20
            e.Graphics.DrawLine(Pens.Black, 30, HH, 820, HH)
            HH += 3
            LineNumber += 1
            If LineNumber = LinePerpAge Then
                LineNumber = 0
                I_Start = I_Counter + 1
                HH = 50
                e.HasMorePages = True
                Exit For
            End If
            e.Graphics.DrawLine(Pens.Black, 30, 130, 30, HH)
            e.Graphics.DrawLine(Pens.Black, 170, 130, 170, HH)
            e.Graphics.DrawLine(Pens.Black, 340, 130, 340, HH)
            e.Graphics.DrawLine(Pens.Black, 440, 130, 440, HH)
            e.Graphics.DrawLine(Pens.Black, 630, 130, 630, HH)
            e.Graphics.DrawLine(Pens.Black, 820, 130, 820, HH)
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim Date1 As Date = DateTimePicker1.Value
        Dim Date2 As Date = DateTimePicker2.Value.AddDays(1)

        Try
            Dim i As Integer = 0
            LV.Items.Clear()
            LV.View = View.Details
            mycmd.Connection = myconnection.open
            mycmd.CommandText = "select * from tbpatient WHERE DATETIME >= '" + Format(Date1, "yyyy-MM-dd") + "' AND DATETIME <= '" + Format(Date2, "yyyy-MM-dd") + "'"
            objreader = mycmd.ExecuteReader
            While objreader.Read
                LV.Items.Add(objreader.Item("ID"))
                LV.Items(i).SubItems.Add(objreader.Item("DATETIME"))
                LV.Items(i).SubItems.Add(objreader.Item("NAME"))
                LV.Items(i).SubItems.Add(objreader.Item("YEARSECTION"))
                LV.Items(i).SubItems.Add(objreader.Item("COMPLAINTSIMPRESSION"))
                LV.Items(i).SubItems.Add(objreader.Item("TREATMENTMEDICINES"))
                i += 1
            End While
            myconnection.close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try

        LinePerpAge = 40

        PrintDialog1.Document = PrintDocument1
        If PrintDialog1.ShowDialog = DialogResult.OK Then
            PrintDialog1.PrinterSettings = PrintDocument1.PrinterSettings
            Dim Mew_Paper As New PaperSize("", 3300, 2550)
            Mew_Paper.PaperName = PaperKind.Custom
            Dim New_margin As New Margins
            New_margin.Left = 0
            New_margin.Top = 50

            With PrintDocument1
                .DefaultPageSettings.PaperSize = Mew_Paper
                .DefaultPageSettings.Margins = New_margin
                .PrinterSettings.DefaultPageSettings.Landscape = True
                .Print()
            End With
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Dim Date1 As Date = DateTimePicker1.Value
        Dim Date2 As Date = DateTimePicker2.Value.AddDays(1)

        Try
            Dim isi As ListViewItem
            LV.Items.Clear()
            mycmd.Connection = myconnection.open
            mycmd.CommandText = "select * from tbpatient WHERE DATETIME >= '" + Format(Date1, "yyyy-MM-dd") + "' AND DATETIME <= '" + Format(Date2, "yyyy-MM-dd") + "'"
            objreader = mycmd.ExecuteReader
            While objreader.Read
                isi = LV.Items.Add(objreader.Item("id").ToString)
                isi.SubItems.Add(objreader.Item("DATETIME").ToString)
                isi.SubItems.Add(objreader.Item("NAME").ToString)
                isi.SubItems.Add(objreader.Item("YEARSECTION").ToString)
                isi.SubItems.Add(objreader.Item("COMPLAINTSIMPRESSION").ToString)
                isi.SubItems.Add(objreader.Item("TREATMENTMEDICINES").ToString)
            End While
            myconnection.close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Dim Date1 As Date = DateTimePicker1.Value
        Dim Date2 As Date = DateTimePicker2.Value.AddDays(1)

        Try
            Dim isi As ListViewItem
            LV.Items.Clear()
            mycmd.Connection = myconnection.open
            mycmd.CommandText = "select * from tbpatient WHERE DATETIME >= '" + Format(Date1, "yyyy-MM-dd") + "' AND DATETIME <= '" + Format(Date2, "yyyy-MM-dd") + "'"
            objreader = mycmd.ExecuteReader
            While objreader.Read
                isi = LV.Items.Add(objreader.Item("id").ToString)
                isi.SubItems.Add(objreader.Item("DATETIME").ToString)
                isi.SubItems.Add(objreader.Item("NAME").ToString)
                isi.SubItems.Add(objreader.Item("YEARSECTION").ToString)
                isi.SubItems.Add(objreader.Item("COMPLAINTSIMPRESSION").ToString)
                isi.SubItems.Add(objreader.Item("TREATMENTMEDICINES").ToString)
            End While
            myconnection.close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub PrintDocument2_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PrintDocument2.PrintPage
        HH = 30
        e.Graphics.DrawString("Polytechnic University of the Philippines", New Drawing.Font("Times New Roman", 14), Brushes.Black, 260, HH)
        e.Graphics.DrawString("Sto. Tomas Branch", New Drawing.Font("Times New Roman", 12), Brushes.Black, 360, HH + 25)
        e.Graphics.DrawString("Sto. Tomas Batangas", New Drawing.Font("Times New Roman", 12), Brushes.Black, 355, HH + 45)
        e.Graphics.DrawString("Medicine and Supplies as of " + Date.Today.ToLongDateString, New Drawing.Font("Times New Roman", 14), Brushes.Black, 210, HH + 80)

        e.Graphics.DrawString("NAME :  __________________________________________________", New Drawing.Font("Times New Roman", 12), Brushes.Black, 30, HH + 120)
        e.Graphics.DrawString("POSITION : _______________________________________________", New Drawing.Font("Times New Roman", 12), Brushes.Black, 30, HH + 150)
        e.Graphics.DrawString("Date of Submission : " + Date.Today.AddMonths(1).Month.ToString + "/01/" + Date.Today.Year.ToString, New Drawing.Font("Times New Roman", 12), Brushes.Black, 550, HH + 120)
        e.Graphics.DrawString("Unit/Dept : Medical Service", New Drawing.Font("Times New Roman", 12), Brushes.Black, 550, HH + 150)

        e.Graphics.DrawString(" Prepared by:", New Drawing.Font("Times New Roman", 12), Brushes.Black, 70, 980)
        e.Graphics.DrawString(" HILARION HENRY MALASIQUE RN MAN", New Drawing.Font("Times New Roman", 12), Brushes.Black, 70, HH + 1008)
        e.Graphics.DrawString(" ______________________________________", New Drawing.Font("Times New Roman", 12), Brushes.Black, 70, HH + 1010)
        e.Graphics.DrawString("            GIL G. NAVERA MD", New Drawing.Font("Times New Roman", 12), Brushes.Black, 480, HH + 1008)
        e.Graphics.DrawString(" _____________________________", New Drawing.Font("Times New Roman", 12), Brushes.Black, 480, HH + 1010)
        e.Graphics.DrawString(" Public Health Nurse I", New Drawing.Font("Times New Roman", 11), Brushes.Black, 150, HH + 1030)
        e.Graphics.DrawString(" School Physician", New Drawing.Font("Times New Roman", 11), Brushes.Black, 550, HH + 1030)

        HH += 200
        e.Graphics.DrawLine(Pens.Black, 30, HH, 820, HH)
        e.Graphics.DrawString("DATE", New Drawing.Font("Times New Roman", 12), Brushes.Black, 45, HH + 5)
        e.Graphics.DrawString("MEDICINES AND MATERIALS", New Drawing.Font("Times New Roman", 12), Brushes.Black, 160, HH + 5)
        e.Graphics.DrawString("QUANTITY", New Drawing.Font("Times New Roman", 12), Brushes.Black, 470, HH + 5)
        e.Graphics.DrawString("CONSUMED", New Drawing.Font("Times New Roman", 12), Brushes.Black, 590, HH + 5)
        e.Graphics.DrawString("BALANCE", New Drawing.Font("Times New Roman", 12), Brushes.Black, 720, HH + 5)
        HH += 30
        Dim NN As Integer
        NN = HH
        e.Graphics.DrawLine(Pens.Black, 30, NN, 820, NN)

        For Me.I_Counter = I_Start To LV2.Items.Count - 1
            e.Graphics.DrawString(LV2.Items(I_Counter).SubItems(1).Text, New Drawing.Font("Times New Roman", 9), Brushes.Black, 33, HH + 5)
            e.Graphics.DrawString(LV2.Items(I_Counter).SubItems(2).Text, New Drawing.Font("Times New Roman", 9), Brushes.Black, 123, HH + 5)
            e.Graphics.DrawString(LV2.Items(I_Counter).SubItems(3).Text, New Drawing.Font("Times New Roman", 9), Brushes.Black, 463, HH + 5)
            e.Graphics.DrawString(LV2.Items(I_Counter).SubItems(4).Text, New Drawing.Font("Times New Roman", 9), Brushes.Black, 583, HH + 5)
            e.Graphics.DrawString(LV2.Items(I_Counter).SubItems(5).Text, New Drawing.Font("Times New Roman", 9), Brushes.Black, 703, HH + 5)
            HH += 20
            e.Graphics.DrawLine(Pens.Black, 30, HH, 820, HH)
            HH += 3
            LineNumber += 1
            If LineNumber = LinePerpAge Then
                LineNumber = 0
                I_Start = I_Counter + 1
                HH = 50
                e.HasMorePages = True
                Exit For
            End If
            e.Graphics.DrawLine(Pens.Black, 30, 230, 30, HH + 20)
            e.Graphics.DrawLine(Pens.Black, 120, 230, 120, HH + 20)
            e.Graphics.DrawLine(Pens.Black, 460, 230, 460, HH + 20)
            e.Graphics.DrawLine(Pens.Black, 580, 230, 580, HH + 20)
            e.Graphics.DrawLine(Pens.Black, 700, 230, 700, HH + 20)
            e.Graphics.DrawLine(Pens.Black, 820, 230, 820, HH + 20)
        Next

    End Sub
End Class
