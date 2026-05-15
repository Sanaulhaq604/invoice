Public Class COA

    Dim lastID As Integer = 0
    Dim OldRno As Integer = 0

    Sub Start()
        Dim maxID As DataTable = SQLData("Select max(id) ID from coa")
        If maxID.Rows.Count > 0 Then
            txtID.Text = maxID.Rows(0)("ID")
            lastID = Form3.Numbers(txtID.Text)
        Else
            txtID.Text = 0
        End If
    End Sub


    Sub AccountIDWise(ACID)

        Dim dt As DataTable = SQLData("Select isnull(control,'') control,isnull(Balance_Date,getdate()) odate,isnull(rno,0) rnoo, isnull(cell2,'') MOBILE2,isnull(status,'') Statuss, isnull(OcellNetwork,'') MobileNetwork,isnull(Ocell2Network,'') Mobile2Network,isnull(OcellWA,'') MobileWA,isnull(Ocell2WA,'') Mobile2WA,isnull(RunsDate,'2020-1-1') RDate,isnull(CreditDays,0) CDays,isnull(CreditLimit,0) CLimit, isnull(Terms,'') Cterms,* from coa where id=" & ACID)
        If dt.Rows.Count > 0 Then
            cmbCategory.Text = dt.Rows(0)("Category")
            cmbStatus.Text = dt.Rows(0)("Statuss")
            cmbMain.Text = dt.Rows(0)("Main")
            cmbControl.Text = dt.Rows(0)("Control")
            txtTitle.Text = dt.Rows(0)("Subsidary")
            txtUrduName.Text = dt.Rows(0)("UrduName").ToString
            cmbSPO.Text = dt.Rows(0)("SPO").ToString
            cmbSM.Text = dt.Rows(0)("SM").ToString
            cmbVehicle.Text = dt.Rows(0)("van").ToString
            cmbRoute.Text = dt.Rows(0)("Route").ToString
            txtPerson.Text = dt.Rows(0)("ContactPerson").ToString
            txtPhone.Text = dt.Rows(0)("OPhone").ToString
            txtCell.Text = dt.Rows(0)("OCell").ToString
            txtAddress2.Text = dt.Rows(0)("OAddress").ToString
            cmbArea.Text = dt.Rows(0)("Area").ToString
            cmbCity.Text = dt.Rows(0)("City").ToString
            txtEmail.Text = dt.Rows(0)("Email").ToString
            txtCode.Text = dt.Rows(0)("Code").ToString
            txtoBal.Text = Form3.Numbers(dt.Rows(0)("balance").ToString)
            dtpOdate.Value = dt.Rows(0)("odate")
            txtRNO.Text = dt.Rows(0)("rnoo")
            txtOcell2.Text = dt.Rows(0)("MOBILE2")
            cmbOcellNetwork.Text = dt.Rows(0)("MobileNetwork")
            cmbOcell2Network.Text = dt.Rows(0)("Mobile2Network")
            cmbOCellWhatsapp.Text = dt.Rows(0)("MobileWA")
            cmbOCell2Whatsapp.Text = dt.Rows(0)("Mobile2WA")
            dtpRDate.Value = dt.Rows(0)("RDate")
            cmbTerms.Text = dt.Rows(0)("Cterms")
            txtcLimit.Text = Form3.Amt(dt.Rows(0)("CLimit"))
            txtcDays.Text = dt.Rows(0)("CDays")
            '  Dim dt2 As DataTable
            Dim companydt As DataTable

            If ACID <> Nothing Then
                companydt = SQLData("select distinct company from Products ORDER BY COMPANY")
                colCompany.Items.Clear()
                For n = 0 To companydt.Rows.Count - 1
                    colCompany.Items.Add(companydt.Rows(n)("Company"))
                Next
                'colCompany.DataSource = companydt
                colCompany.DisplayMember = "Company"
                colCompany.ValueMember = "Company"
                PriceList.Items.Clear()
                PriceList.Items.Add("A")
                PriceList.Items.Add("B")
                PriceList.Items.Add("C")
                PriceList.Items.Add("P")
                CompanyDiscountGridDisplay()
                'dt2 = SQLData("select row_number() over(order by company) RN,Company,isnull(PriceList,'') PriceList,isnull(Disc1P,0) Disc1P,isnull(discount,0) Discount,id from PartyDiscount where acid=" & ACID & " Order by id ")
                'If dt2.Rows.Count > 0 Then
                '    dgvCompanyDiscount.DataSource = dt2
                '    Dim LastRow As Integer = dgvCompanyDiscount.Rows.Count - 1
                '    dgvCompanyDiscount.Rows(LastRow).Selected = True
                '    dgvCompanyDiscount.FirstDisplayedScrollingRowIndex = LastRow
                'Else
                '    If dgvCompanyDiscount.Rows.Count > 0 Then
                '        '      dgvCompanyDiscount.DataSource.clear()
                '    End If
                'End If
            End If
            If Convert.ToDateTime(dtpRDate.Value) < Convert.ToDateTime("01-06-2020") Then
                lblRuns.BackColor = Color.Red
                lblRuns.ForeColor = Color.White
            Else
                lblRuns.BackColor = Color.Transparent
                lblRuns.ForeColor = Color.Black
            End If
            If frmLogin.UserLevel.ToUpper = "ADMIN" Then
                If cmbMain.Text = "STAFF" Then
                    lblLimit.Text = "SALARY"
                Else
                    lblLimit.Text = "CREDIT LIMIT"
                End If
            Else
                txtcLimit.ForeColor = Color.White
            End If

            'dtpOdate.Value = dt.Rows(0)("Balance_Date").value.ToString("d")
        Else

            End If
        txtID.Select()
        txtID.SelectAll()
    End Sub

    Sub AllClear()
        txtTitle.Text = ""
        txtUrduName.Text = ""
        cmbSPO.Text = ""
        cmbSM.Text = ""
        cmbVehicle.Enabled = Text = ""
        cmbRoute.Text = ""
        txtPerson.Text = ""
        txtPhone.Text = ""
        txtCell.Text = ""
        txtAddress2.Text = ""
        cmbArea.Text = ""
        cmbCity.Text = ""
        txtEmail.Text = ""
        txtoBal.Text = ""
        txtRNO.Text = ""
        txtDay.Text = ""
        cmbStatus.Text = ""

    End Sub

    Private Sub COA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Start()
        AccountIDWise(txtID.Text)
        CustomerList()
        'LoadCmoboBox()
    End Sub

    Sub LoadCmoboBox()
        Dim companydt = SQLData("select distinct company from Products ORDER BY COMPANY")
        colCompany.Items.Clear()
        For n = 0 To companydt.Rows.Count - 1
            colCompany.Items.Add(companydt.Rows(n)("Company"))
        Next
        'colCompany.DataSource = companydt
        'colCompany.DisplayMember = "Company"
        'colCompany.ValueMember = "Company"
        PriceList.Items.Clear()
        PriceList.Items.Add("A")
        PriceList.Items.Add("B")
        PriceList.Items.Add("C")
        PriceList.Items.Add("P")
    End Sub


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
        SQLData("delete from coa where main='' and control='' and category='' and subsidary=''   ")
    End Sub

    Sub CustomerList()
        Dim dt As DataTable = SQLData("select id,Subsidary,UrduName,OAddress,city,ocell,cell2,route,spo,contactperson from coa where subsidary like '%" & txtSearchTitle.Text & "%' and spo like '%" & txtSearchSPO.Text & "%'  and route like '%" & txtSearchRoute.Text & "%' and (ocell like '%" & txtSearchCell.Text & "%' or cell2 like '%" & txtSearchCell.Text & "%' )")
        If dt.Rows.Count > 0 Then
            dgvCOA.DataSource = dt
        Else
            dgvCOA.DataSource.clear()
        End If

    End Sub

    Private Sub txtID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtID.KeyDown
        If e.KeyCode = Keys.Up And Form3.Numbers(txtID.Text) < lastID Then
            imgShop.Image = Nothing
            imgCustomer.Image = Nothing
            imgAgreement.Image = Nothing
            txtID.Text += 1
            AccountIDWise(txtID.Text)
            LoadImages(txtID.Text)

        End If
        If e.KeyCode = Keys.Down And Form3.Numbers(txtID.Text) <= lastID Then
            imgShop.Image = Nothing
            imgCustomer.Image = Nothing
            imgAgreement.Image = Nothing
            txtID.Text -= 1
            AccountIDWise(txtID.Text)
            LoadImages(txtID.Text)
        End If
        If e.KeyCode = Keys.Enter And Form3.Numbers(txtID.Text) <= lastID Then
            imgShop.Image = Nothing
            imgCustomer.Image = Nothing
            imgAgreement.Image = Nothing
            AccountIDWise(txtID.Text)
            LoadImages(txtID.Text)

        End If


    End Sub

    Private Sub txtID_Enter(sender As Object, e As EventArgs) Handles txtID.Enter
        txtID.SelectAll()
    End Sub

    Private Sub txtCode_Enter(sender As Object, e As EventArgs) Handles txtCode.Enter
        txtCode.SelectAll()
    End Sub



    Private Sub dgvCOA_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCOA.CellDoubleClick
        txtID.Text = dgvCOA.CurrentRow.Cells("colID").Value.ToString
        AccountIDWise(txtID.Text)
    End Sub

    Private Sub txtSearchTitle_Leave(sender As Object, e As EventArgs) Handles txtSearchTitle.Leave, txtSearchRoute.Leave, txtSearchSPO.Leave, txtSearchCell.Leave, txtSearchTitle.TextChanged, txtSearchRoute.TextChanged, txtSearchSPO.TextChanged, txtSearchCell.TextChanged
        CustomerList()
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click
        If frmLogin.UserLevel = "Operator" Then
            MsgBox("USER NOT ALLOWED")
            Return
        End If
        AllClear()
        SQLData("insert into coa (date,id,code,category,MAIN,control,SUBSIDARY,email,oaddress,city,contactperson,area,OCELL,route)
                                 values(getdate()," & lastID + 1 & ",'" & lastID + 1 & "','BALANCE SHEET','TRADE DEBTORS','COUNTER','', '', '', '' , '', '','',''   )")
        Start()
        cmbCategory.Text = "Balance Sheet"
        cmbMain.Text = "TRADE DEBTORS"
        cmbControl.Text = "COUNTER"
        AccountIDWise(txtID.Text)
        txtTitle.Select()
        txtTitle.SelectAll()
    End Sub

    Private Sub txtCode_Leave(sender As Object, e As EventArgs) Handles txtCode.Leave
        SQLData("update coa set code='" & txtCode.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub cmbCategory_Leave(sender As Object, e As EventArgs) Handles cmbCategory.Leave
        SQLData("update coa set category='" & cmbCategory.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub cmbMain_Leave(sender As Object, e As EventArgs) Handles cmbMain.Leave
        SQLData("update coa set main='" & cmbMain.Text & "' where id=" & txtID.Text)
        If cmbMain.Text = "STAFF" Then
            lblLimit.Text = "SALARY"
        Else
            lblLimit.Text = "CREDIT LIMIT"
        End If
        CustomerList()
    End Sub

    Private Sub cmbControl_Leave(sender As Object, e As EventArgs) Handles cmbControl.Leave
        SQLData("update coa set control='" & cmbControl.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub txtTitle_Leave(sender As Object, e As EventArgs) Handles txtTitle.Leave
        If frmLogin.UserLevel.ToUpper <> "ADMIN" Then
            Return
        End If
        SQLData("update coa set subsidary='" & txtTitle.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub txtUrduName_Leave(sender As Object, e As EventArgs) Handles txtUrduName.Leave
        SQLData("update coa set UrduName=N'" & txtUrduName.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub cmbSPO_Leave(sender As Object, e As EventArgs) Handles cmbSPO.Leave
        SQLData("update coa set spo='" & cmbSPO.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub cmbSM_Leave(sender As Object, e As EventArgs) Handles cmbSM.Leave
        SQLData("update coa set sm='" & cmbSM.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub cmbRoute_Leave(sender As Object, e As EventArgs) Handles cmbRoute.Leave
        SQLData("update coa set route='" & cmbRoute.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub cmbVehicle_Leave(sender As Object, e As EventArgs) Handles cmbVehicle.Leave
        SQLData("update coa set van='" & cmbVehicle.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub txtPerson_Leave(sender As Object, e As EventArgs) Handles txtPerson.Leave
        SQLData("update coa set ContactPerson='" & txtPerson.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub txtPhone_Leave(sender As Object, e As EventArgs) Handles txtPhone.Leave
        SQLData("update coa set oPhone='" & txtPhone.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub txtCell_Leave(sender As Object, e As EventArgs)
        SQLData("update coa set oCell='" & txtCell.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub txtAddress_Leave(sender As Object, e As EventArgs) Handles txtAddress2.Leave
        SQLData("update coa set OAddress=  '" & txtAddress2.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub cmbArea_Leave(sender As Object, e As EventArgs) Handles cmbArea.Leave
        SQLData("update coa set area='" & cmbArea.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub cmbCity_Leave(sender As Object, e As EventArgs) Handles cmbCity.Leave
        SQLData("update coa set City='" & cmbCity.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub txtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        SQLData("update coa set email='" & txtEmail.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub dtpOdate_Leave(sender As Object, e As EventArgs) Handles dtpOdate.Leave
        SQLData("update coa set Balance_Date='" & dtpOdate.Value.ToString("d") & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub txtoBal_Leave(sender As Object, e As EventArgs) Handles txtoBal.Leave
        SQLData("update coa set balance=" & Form3.Numbers(txtoBal.Text) & " where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

        Start()
        AccountIDWise(txtID.Text)
    End Sub

    Private Sub txtTitle_Enter(sender As Object, e As EventArgs) Handles txtTitle.Enter
        txtTitle.SelectAll()
    End Sub

    Private Sub cmbCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategory.TextChanged
        Dim SELSTART As Integer = cmbCategory.SelectionStart
        cmbCategory.Text = cmbCategory.Text.ToUpper()
        cmbCategory.SelectionStart = SELSTART
    End Sub

    Private Sub cmbMain_TextChanged(sender As Object, e As EventArgs) Handles cmbMain.TextChanged
        Dim SELSTART As Integer = cmbMain.SelectionStart
        cmbMain.Text = cmbMain.Text.ToUpper()
        cmbMain.SelectionStart = SELSTART
    End Sub

    Private Sub cmbControl_TextChanged(sender As Object, e As EventArgs) Handles cmbControl.TextChanged
        Dim SELSTART As Integer = cmbControl.SelectionStart
        cmbControl.Text = cmbControl.Text.ToUpper()
        cmbControl.SelectionStart = SELSTART
    End Sub

    Private Sub cmbSPO_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSPO.TextChanged
        Dim SELSTART As Integer = cmbSPO.SelectionStart
        cmbSPO.Text = cmbSPO.Text.ToUpper()
        cmbSPO.SelectionStart = SELSTART
    End Sub

    Private Sub cmbSM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSM.TextChanged
        Dim SELSTART As Integer = cmbSM.SelectionStart
        cmbSM.Text = cmbSM.Text.ToUpper()
        cmbSM.SelectionStart = SELSTART
    End Sub

    Private Sub cmbRoute_TextChanged(sender As Object, e As EventArgs) Handles cmbRoute.TextChanged
        Dim SELSTART As Integer = cmbRoute.SelectionStart
        cmbRoute.Text = cmbRoute.Text.ToUpper()
        cmbRoute.SelectionStart = SELSTART
    End Sub

    Private Sub cmbVehicle_TextChanged(sender As Object, e As EventArgs) Handles cmbVehicle.TextChanged
        Dim SELSTART As Integer = cmbVehicle.SelectionStart
        cmbVehicle.Text = cmbVehicle.Text.ToUpper()
        cmbVehicle.SelectionStart = SELSTART
    End Sub

    Private Sub cmbArea_TextChanged(sender As Object, e As EventArgs) Handles cmbArea.TextChanged
        Dim SELSTART As Integer = cmbArea.SelectionStart
        cmbArea.Text = cmbArea.Text.ToUpper()
        cmbArea.SelectionStart = SELSTART
    End Sub

    Private Sub cmbCity_TextChanged(sender As Object, e As EventArgs) Handles cmbCity.TextChanged
        Dim SELSTART As Integer = cmbCity.SelectionStart
        cmbCity.Text = cmbCity.Text.ToUpper()
        cmbCity.SelectionStart = SELSTART
    End Sub

    Private Sub cmbCategory_Enter(sender As Object, e As EventArgs) Handles cmbCategory.Enter
        Dim dt As DataTable = SQLData("select distinct category from coa where category<>'' order by category")
        cmbCategory.Items.Clear()
        If dt.Rows.Count > 0 Then
            For n = 0 To dt.Rows.Count - 1
                cmbCategory.Items.Add(dt.Rows(n)("Category"))
            Next
        End If
    End Sub

    Private Sub cmbMain_Enter(sender As Object, e As EventArgs) Handles cmbMain.Enter
        Dim dt As DataTable = SQLData("select distinct main from coa where main<>'' and category='" & cmbCategory.Text & "' order by main")
        cmbMain.Items.Clear()
        If dt.Rows.Count > 0 Then
            For n = 0 To dt.Rows.Count - 1
                cmbMain.Items.Add(dt.Rows(n)("Main"))
            Next
        End If
    End Sub

    Private Sub cmbControl_Enter(sender As Object, e As EventArgs) Handles cmbControl.Enter
        Dim dt As DataTable = SQLData("select distinct control from coa where control<>'' and main='" & cmbMain.Text & "' order by control")
        cmbControl.Items.Clear()
        If dt.Rows.Count > 0 Then
            For n = 0 To dt.Rows.Count - 1
                cmbControl.Items.Add(dt.Rows(n)("Control"))
            Next
        End If
    End Sub

    Private Sub cmbSPO_Enter(sender As Object, e As EventArgs) Handles cmbSPO.Enter
        Dim dt As DataTable = SQLData("select distinct SPO from coa where spo<>'' order by spo")
        cmbSPO.Items.Clear()
        If dt.Rows.Count > 0 Then
            For n = 0 To dt.Rows.Count - 1
                cmbSPO.Items.Add(dt.Rows(n)("SPO"))
            Next
        End If
    End Sub

    Private Sub cmbSM_Enter(sender As Object, e As EventArgs) Handles cmbSM.Enter
        Dim dt As DataTable = SQLData("select distinct SM from coa where sm<>'' order by sm")
        cmbSM.Items.Clear()
        If dt.Rows.Count > 0 Then
            For n = 0 To dt.Rows.Count - 1
                cmbSM.Items.Add(dt.Rows(n)("SM"))
            Next
        End If
    End Sub

    Private Sub cmbRoute_Enter(sender As Object, e As EventArgs) Handles cmbRoute.Enter
        Dim dt As DataTable = SQLData("select distinct Route from coa where route<>'' order by route")
        cmbRoute.Items.Clear()
        If dt.Rows.Count > 0 Then
            For n = 0 To dt.Rows.Count - 1
                cmbRoute.Items.Add(dt.Rows(n)("Route"))
            Next
        End If
    End Sub

    Private Sub cmbVehicle_Enter(sender As Object, e As EventArgs) Handles cmbVehicle.Enter
        Dim van As DataTable = SQLData("select distinct Van from coa where van<>'' order by van")
        cmbVehicle.Items.Clear()
        If van.Rows.Count > 0 Then
            For n = 0 To van.Rows.Count - 1
                cmbVehicle.Items.Add(van.Rows(n)("Van"))
            Next
        End If
    End Sub

    Private Sub cmbArea_Enter(sender As Object, e As EventArgs) Handles cmbArea.Enter
        Dim dt As DataTable = SQLData("select distinct Area from coa where area<>'' order by area")
        cmbArea.Items.Clear()
        If dt.Rows.Count > 0 Then
            For n = 0 To dt.Rows.Count - 1
                cmbArea.Items.Add(dt.Rows(n)("Area"))
            Next
        End If
    End Sub

    Private Sub cmbCity_Enter(sender As Object, e As EventArgs) Handles cmbCity.Enter
        Dim dt As DataTable = SQLData("select distinct City from coa where city<>'' order by city")
        cmbCity.Items.Clear()
        If dt.Rows.Count > 0 Then
            For n = 0 To dt.Rows.Count - 1
                cmbCity.Items.Add(dt.Rows(n)("City"))
            Next
        End If
    End Sub

    Private Sub txtCell2_Leave(sender As Object, e As EventArgs) Handles txtCell.Leave


        'MsgBox(txtCell.Text)

        SQLData("update coa set oCell='" & txtCell.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub txtRNO_Leave(sender As Object, e As EventArgs) Handles txtRNO.Leave
        If cmbRoute.Text = "" Then
            MsgBox("Please Select Route First")
            cmbRoute.Select()
            Return
        End If

        If OldRno = 0 Then
            SQLData("update coa set rno=rno+1 where rno>= " & txtRNO.Text & " and route= '" & cmbRoute.Text & "'")
            SQLData("update coa set rno= " & txtRNO.Text & " where id= " & txtID.Text)
        ElseIf OldRno < txtRNO.Text Then
            SQLData("update coa set rno=rno-1 where rno>" & OldRno & " and   rno<= " & txtRNO.Text & " and route= '" & cmbRoute.Text & "'")
            SQLData("update coa set rno= " & txtRNO.Text & " where id= " & txtID.Text)
        ElseIf OldRno > txtRNO.Text Then
            SQLData("update coa set rno=rno+1 where rno>=" & txtRNO.Text & " and   rno< " & OldRno & " and route= '" & cmbRoute.Text & "'")
            SQLData("update coa set rno= " & txtRNO.Text & " where id= " & txtID.Text)
        End If


    End Sub

    Private Sub txtRNO_Enter(sender As Object, e As EventArgs) Handles txtRNO.Enter

        OldRno = txtRNO.Text
        txtRNO.SelectAll()
    End Sub

    Private Sub Ocell2_Leave(sender As Object, e As EventArgs) Handles txtOcell2.Leave
        SQLData("update coa set Cell2='" & txtOcell2.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub cmbOcellNetwork_Leave(sender As Object, e As EventArgs) Handles cmbOcellNetwork.Leave
        SQLData("update coa set oCellNetwork='" & cmbOcellNetwork.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub cmbOcellNetwork_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOcellNetwork.SelectedIndexChanged

    End Sub

    Private Sub cmbOCellWhatsapp_Leave(sender As Object, e As EventArgs) Handles cmbOCellWhatsapp.Leave
        SQLData("update coa set oCellWA='" & cmbOCellWhatsapp.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub cmbOcell2Network_Leave(sender As Object, e As EventArgs) Handles cmbOcell2Network.Leave
        SQLData("update coa set oCell2Network='" & cmbOcell2Network.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub cmbOCell2Whatsapp_Leave(sender As Object, e As EventArgs) Handles cmbOCell2Whatsapp.Leave
        SQLData("update coa set oCell2WA='" & cmbOCell2Whatsapp.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub ComboBox1_Leave(sender As Object, e As EventArgs) Handles cmbTerms.Leave
        SQLData("update coa set terms='" & cmbTerms.Text & "' where id=" & txtID.Text)
    End Sub

    Private Sub txtcLimit_Leave(sender As Object, e As EventArgs) Handles txtcLimit.Leave
        SQLData("update coa set creditlimit='" & Val(txtcLimit.Text) & "' where id=" & txtID.Text)
    End Sub

    Private Sub txtcDays_Leave(sender As Object, e As EventArgs) Handles txtcDays.Leave
        SQLData("update coa set creditDays='" & Val(txtcDays.Text) & "' where id=" & txtID.Text)
    End Sub

    Private Sub txtID_Leave(sender As Object, e As EventArgs) Handles txtID.Leave
        If txtID.Text <> txtCode.Text Then
            AccountIDWise(txtID.Text)
            LoadImages(txtID.Text)
        End If
    End Sub

    Sub LoadImages(CusID As Integer)
        Dim dt As DataTable = SQLImageData("select ACID
,CASE WHEN SHOP IS NULL THEN 'NO IMAGE' ELSE 'IMAGE' END SHOP 
,CASE WHEN CUSTOMER IS NULL THEN 'NO IMAGE' ELSE 'IMAGE' END CUSTOMER
,CASE WHEN Agreement IS NULL THEN 'NO IMAGE' ELSE 'IMAGE' END AGREEMENT 
from COAImages WHERE acid=" & CusID)
        Dim ShopImage As String = ""
        Dim CustomerImage As String = ""
        Dim AgreementImage As String = ""
        If dt.Rows.Count = 0 Then
            imgShop.Image = Nothing
            imgCustomer.Image = Nothing
            imgAgreement.Image = Nothing
            btnLoadAgreementImage.Enabled = False
            btnLoadCustomerImage.Enabled = False
            btnLoadShopImage.Enabled = False
            btnCustomerRotate.Enabled = False
            btnShopRotate.Enabled = False
            btnAgreementRotate.Enabled = False
            Return
        Else
            ShopImage = dt.Rows(0)("shop").ToString
            CustomerImage = dt.Rows(0)("Customer").ToString
            AgreementImage = dt.Rows(0)("Agreement").ToString
            If ShopImage = "IMAGE" Then
                btnShopRotate.Enabled = True
                btnLoadShopImage.Enabled = True
                btnLoadShopImage.BackColor = Color.LightGreen
            Else
                btnShopRotate.Enabled = False
                btnLoadShopImage.Enabled = False
                btnLoadShopImage.BackColor = Color.Transparent
            End If
            If CustomerImage = "IMAGE" Then
                btnCustomerRotate.Enabled = True
                btnLoadCustomerImage.Enabled = True
            Else
                btnCustomerRotate.Enabled = False
                btnLoadCustomerImage.Enabled = False
            End If
            If AgreementImage = "IMAGE" Then
                btnAgreementRotate.Enabled = True
                btnLoadAgreementImage.Enabled = True
                btnLoadAgreementImage.BackColor = Color.LightGreen
            Else
                btnAgreementRotate.Enabled = False
                btnLoadAgreementImage.Enabled = False
                btnLoadAgreementImage.BackColor = Color.Transparent
            End If
            'btnLoadAgreementImage.Enabled = True
            'btnLoadCustomerImage.Enabled = True
            'btnLoadShopImage.Enabled = True
            'btnCustomerRotate.Enabled = True
            'btnShopRotate.Enabled = True
            'btnAgreementRotate.Enabled = True
        End If
        ' Reset all images first
        'imgShop.Image = Nothing
        'imgCustomer.Image = Nothing
        'imgAgreement.Image = Nothing

        'If dt.Rows.Count > 0 Then
        '    ' Shop image


        '    ' Customer image
        '    If dt.Columns.Contains("customer") AndAlso dt.Rows(0)("customer") IsNot DBNull.Value Then
        '        Dim img() As Byte = DirectCast(dt.Rows(0)("customer"), Byte())
        '        If img.Length > 0 Then
        '            Try
        '                Using ms As New IO.MemoryStream(img)
        '                    imgCustomer.Image = Image.FromStream(ms, True, True)
        '                End Using
        '            Catch ex As Exception
        '                MsgBox("Customer image load failed: " & ex.Message)
        '            End Try
        '        End If
        '    End If

        '    ' Agreement image
        '    If dt.Columns.Contains("agreement") AndAlso dt.Rows(0)("agreement") IsNot DBNull.Value Then
        '        Dim img() As Byte = DirectCast(dt.Rows(0)("agreement"), Byte())
        '        If img.Length > 0 Then
        '            Try
        '                Using ms As New IO.MemoryStream(img)
        '                    imgAgreement.Image = Image.FromStream(ms, True, True)
        '                End Using
        '            Catch ex As Exception
        '                MsgBox("Agreement image load failed: " & ex.Message)
        '            End Try
        '        End If
        '    End If
        'End If
    End Sub


    Private Sub cmbStatus_Leave(sender As Object, e As EventArgs) Handles cmbStatus.Leave
        SQLData("update coa set status='" & cmbStatus.Text & "' where id=" & txtID.Text)
        CustomerList()
    End Sub

    Private Sub txtSearchTitle_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearchTitle.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dgvCOA.Rows.Count > 0 Then
                txtID.Text = dgvCOA.Item("COLID", 0).Value.ToString
                AccountIDWise(dgvCOA.Item("COLID", 0).Value.ToString)

            End If
        End If
    End Sub

    Private Sub dtpRDate_Leave(sender As Object, e As EventArgs) Handles dtpRDate.Leave
        SQLData("update coa set RunsDate='" & dtpRDate.Value.ToString("d") & "' where id=" & txtID.Text)
        CustomerList()

    End Sub

    Private Sub btnUpdateCompany_Click(sender As Object, e As EventArgs) Handles btnUpdateCompany.Click
        If dgvCompanyDiscount.Rows.Count > 0 Then
            For n = 0 To dgvCompanyDiscount.Rows.Count - 1
                Dim DiscountCompany As String = dgvCompanyDiscount.Item("colCompany", n).Value.ToString
                Dim DPriceList As String = dgvCompanyDiscount.Item("PriceList", n).Value.ToString()
                Dim Dis1 As String = dgvCompanyDiscount.Item("Disc1P", n).Value.ToString()
                Dim dis2 As String = dgvCompanyDiscount.Item("Discount", n).Value.ToString()
                Dim CusID As String = txtID.Text
                Dim DisID As String = dgvCompanyDiscount.Item("colDisID", n).Value.ToString()
                SQLData("update partydiscount set company='" & DiscountCompany & "',PriceList='" & DPriceList & "',disc1p=" & Dis1 & ",discount=" & dis2 & " where acid='" & CusID & "' and id='" & DisID & "'  ")
                'MsgBox(ms)
            Next
        End If
        CompanyDiscountGridDisplay()

    End Sub



    Private Sub btnRemoveCompany_Click(sender As Object, e As EventArgs) Handles btnRemoveCompany.Click
        MsgBox(dgvCompanyDiscount.CurrentRow.Index)
    End Sub

    Private Sub dgvCompanyDiscount_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvCompanyDiscount.CellValueChanged
        'If dgvCompanyDiscount.Columns(e.ColumnIndex).Name = "colCompany" Then
        'MsgBox(dgvCompanyDiscount.Columns(e.ColumnIndex).Name)
        'End If
    End Sub

    Sub CompanyDiscountGridDisplay()
        If txtID.Text <> Nothing Then
            Dim dt2 As DataTable = SQLData("select row_number() over(order by id,company) RN,Company,isnull(PriceList,'') PriceList,isnull(Disc1P,0) Disc1P,isnull(discount,0) Discount,id from PartyDiscount where acid=" & txtID.Text & "order by id")
            If dt2.Rows.Count > 0 Then
                dgvCompanyDiscount.DataSource = dt2
                Dim LastRow As Integer = dgvCompanyDiscount.Rows.Count - 1
                dgvCompanyDiscount.Rows(LastRow).Selected = True
                dgvCompanyDiscount.FirstDisplayedScrollingRowIndex = LastRow
            Else
                If dgvCompanyDiscount.Rows.Count > 0 Then
                    dgvCompanyDiscount.DataSource.clear()
                End If
            End If
        End If
    End Sub

    Private Sub btnAddCompany_Click(sender As Object, e As EventArgs) Handles btnAddCompany.Click
        SQLData("insert into PartyDiscount (id,acid,company,discount,PriceList,Disc1P) 
                    values ((select isnull(max(id),0) from PartyDiscount where acid='" & txtID.Text & "')+1,'" & txtID.Text & "','',0,'A',0)")
        CompanyDiscountGridDisplay()
    End Sub

    Private Sub dgvCompanyDiscount_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCompanyDiscount.CellFormatting

        If dgvCompanyDiscount IsNot Nothing AndAlso dgvCompanyDiscount.Columns("PriceList") IsNot Nothing Then
            If e.ColumnIndex = dgvCompanyDiscount.Columns("PriceList").Index Then
                e.Value = UCase(e.Value.ToString)
            End If
        End If

    End Sub

    Private Sub dgvCompanyDiscount_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles dgvCompanyDiscount.EditingControlShowing
        If dgvCompanyDiscount.CurrentCell.ColumnIndex = dgvCompanyDiscount.Columns("Disc1P").Index Or dgvCompanyDiscount.CurrentCell.ColumnIndex = dgvCompanyDiscount.Columns("discount").Index Then
            Dim tb As TextBox = e.Control
            AddHandler tb.KeyPress, AddressOf tb_KeyPress
        End If

    End Sub

    Private Sub tb_KeyPress(Sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub dgvCompanyDiscount_CellValidating(sender As Object, e As DataGridViewCellValidatingEventArgs) Handles dgvCompanyDiscount.CellValidating
        If dgvCompanyDiscount.Columns(e.ColumnIndex).Name = "Disc1P" Or dgvCompanyDiscount.Columns(e.ColumnIndex).Name = "DISCOUNT" Then
            If Not IsNumeric(e.FormattedValue) Then
                e.Cancel = True
            End If
            If e.FormattedValue.ToString() = "" Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Function ImageToByteArray(img As Image) As Byte()
        Using ms As New IO.MemoryStream()
            img.Save(ms, Imaging.ImageFormat.Jpeg) ' or PNG
            Return ms.ToArray()
        End Using
    End Function

    Private Sub btnShopRotate_Click(sender As Object, e As EventArgs) Handles btnShopRotate.Click
        If imgShop.Image IsNot Nothing Then
            Dim rotatedImage As New Bitmap(imgShop.Image)
            rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
            imgShop.Image = rotatedImage
            imgShop.Refresh()

            Dim query As String = "UPDATE COAImages SET SHOP = @img WHERE acid = @acid"
            Using conn As New SqlClient.SqlConnection(MainPage.conString2),
                  cmd As New SqlClient.SqlCommand(query, conn)
                If imgShop.Image IsNot Nothing Then
                    cmd.Parameters.Add("@img", SqlDbType.VarBinary).Value = ImageToByteArray(imgShop.Image)
                Else
                    cmd.Parameters.Add("@img", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                cmd.Parameters.Add("@acid", SqlDbType.Int).Value = txtID.Text
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            End Using

        End If
    End Sub

    Private Sub imgShop_Click(sender As Object, e As EventArgs) Handles imgShop.Click
        If imgShop.Image IsNot Nothing Then
            ' create instance of ViewImage form
            Dim f As New ViewImage()
            f.WindowState = FormWindowState.Maximized
            ' set pbBilty image
            f.pbBilty.Image = CType(imgShop.Image.Clone(), Image)

            ' show form
            f.ShowDialog()
        End If
    End Sub

    Private Sub imgCustomer_Click(sender As Object, e As EventArgs) Handles imgCustomer.Click
        If imgCustomer.Image IsNot Nothing Then
            Dim f As New ViewImage()
            f.StartPosition = FormStartPosition.CenterScreen
            f.Height = Screen.PrimaryScreen.WorkingArea.Height
            f.Width = CInt(Screen.PrimaryScreen.WorkingArea.Width * 0.6)
            f.pbBilty.Image = CType(imgCustomer.Image.Clone(), Image)
            f.ShowDialog()
        End If
    End Sub

    Private Sub imgAgreement_Click(sender As Object, e As EventArgs) Handles imgAgreement.Click
        If imgAgreement.Image IsNot Nothing Then
            ' create instance of ViewImage form
            Dim f As New ViewImage()
            f.WindowState = FormWindowState.Maximized
            ' set pbBilty image
            f.pbBilty.Image = CType(imgAgreement.Image.Clone(), Image)

            ' show form
            f.ShowDialog()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnAgreementRotate.Click

        If imgAgreement.Image IsNot Nothing Then
            Dim rotatedImage As New Bitmap(imgAgreement.Image)
            rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
            imgAgreement.Image = rotatedImage
            imgAgreement.Refresh()

            Dim query As String = "UPDATE COAImages SET agreement = @img WHERE acid = @acid"
            Using conn As New SqlClient.SqlConnection(MainPage.conString2),
                  cmd As New SqlClient.SqlCommand(query, conn)
                If imgAgreement.Image IsNot Nothing Then
                    cmd.Parameters.Add("@img", SqlDbType.VarBinary).Value = ImageToByteArray(imgAgreement.Image)
                Else
                    cmd.Parameters.Add("@img", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                cmd.Parameters.Add("@acid", SqlDbType.Int).Value = txtID.Text
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            End Using

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnCustomerRotate.Click
        If imgCustomer.Image IsNot Nothing Then
            Dim rotatedImage As New Bitmap(imgCustomer.Image)
            rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
            imgCustomer.Image = rotatedImage
            imgCustomer.Refresh()

            Dim query As String = "UPDATE COAImages SET Customer = @img WHERE acid = @acid"
            Using conn As New SqlClient.SqlConnection(MainPage.conString2),
                  cmd As New SqlClient.SqlCommand(query, conn)
                If imgCustomer.Image IsNot Nothing Then
                    cmd.Parameters.Add("@img", SqlDbType.VarBinary).Value = ImageToByteArray(imgCustomer.Image)
                Else
                    cmd.Parameters.Add("@img", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                cmd.Parameters.Add("@acid", SqlDbType.Int).Value = txtID.Text
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            End Using

        End If
    End Sub

    Private Sub btnAgreement_Click(sender As Object, e As EventArgs) Handles btnAgreementRotate.Click
        If imgAgreement.Image IsNot Nothing Then
            Dim rotatedImage As New Bitmap(imgAgreement.Image)
            'rotatedImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
            'imgAgreement.Image = rotatedImage
            'imgAgreement.Refresh()

            Dim query As String = "UPDATE COAImages SET agreement = @img WHERE acid = @acid"
            Using conn As New SqlClient.SqlConnection(MainPage.conString2),
                  cmd As New SqlClient.SqlCommand(query, conn)
                If imgAgreement.Image IsNot Nothing Then
                    cmd.Parameters.Add("@img", SqlDbType.VarBinary).Value = ImageToByteArray(imgAgreement.Image)
                Else
                    cmd.Parameters.Add("@img", SqlDbType.VarBinary).Value = DBNull.Value
                End If
                cmd.Parameters.Add("@acid", SqlDbType.Int).Value = txtID.Text
                conn.Open()
                cmd.ExecuteNonQuery()
                conn.Close()
            End Using

        End If
    End Sub

    Private Sub btnLoadShopImage_Click(sender As Object, e As EventArgs) Handles btnLoadShopImage.Click
        Dim dt As DataTable = SQLImageData("SELECT shop FROM COAImages WHERE acid=" & txtID.Text)
        If dt.Rows(0)("shop") IsNot DBNull.Value Then
            Dim img() As Byte = DirectCast(dt.Rows(0)("shop"), Byte())
            If img.Length > 0 Then
                Try
                    Using ms As New IO.MemoryStream(img)
                        imgShop.Image = Image.FromStream(ms, True, True)
                        'imgShop.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                    End Using
                    btnShopRotate.Enabled = True
                Catch ex As Exception
                    btnShopRotate.Enabled = False
                    MsgBox("Shop image load failed: " & ex.Message)

                End Try
                'btnShopRotate.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnLoadCustomerImage_Click(sender As Object, e As EventArgs) Handles btnLoadCustomerImage.Click
        Dim dt As DataTable = SQLImageData("SELECT customer FROM COAImages WHERE acid=" & txtID.Text)
        If dt.Rows(0)("Customer") IsNot DBNull.Value Then
            Dim img() As Byte = DirectCast(dt.Rows(0)("Customer"), Byte())
            If img.Length > 0 Then
                Try
                    Using ms As New IO.MemoryStream(img)
                        imgCustomer.Image = Image.FromStream(ms, True, True)
                        'imgShop.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                    End Using
                    btnCustomerRotate.Enabled = True
                Catch ex As Exception
                    btnCustomerRotate.Enabled = False
                    MsgBox("Shop image load failed: " & ex.Message)

                End Try
                'btnCustomerRotate.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnLoadAgreementImage_Click(sender As Object, e As EventArgs) Handles btnLoadAgreementImage.Click
        Dim dt As DataTable = SQLImageData("SELECT agreement FROM COAImages WHERE acid=" & txtID.Text)
        If dt.Rows(0)("Agreement") IsNot DBNull.Value Then
            Dim img() As Byte = DirectCast(dt.Rows(0)("Agreement"), Byte())
            If img.Length > 0 Then
                Try
                    Using ms As New IO.MemoryStream(img)
                        imgAgreement.Image = Image.FromStream(ms, True, True)
                        'imgShop.Image.RotateFlip(RotateFlipType.Rotate90FlipNone)
                    End Using
                    btnAgreementRotate.Enabled = True
                Catch ex As Exception
                    btnAgreementRotate.Enabled = False
                    MsgBox("Shop image load failed: " & ex.Message)

                End Try
                'btnAgreementRotate.Enabled = False
            End If
        End If

    End Sub



    'Private Sub tbCompanyDiscount_Enter(sender As Object, e As EventArgs) Handles tbCompanyDiscount.Enter
    '    Dim dt As DataTable = SQLData("Select company compy ,PriceList,isnull(Disc1P,0) Disc1P,isnull(discount,0) Discount from partyDiscount where acid=" & txtID.Text)
    '    If dgvCompanyDiscount.Rows.Count > 0 Then
    '        dgvCompanyDiscount.Rows.Clear()
    '    End If
    '    Dim co As DataTable = SQLData("select distinct company from products where company is not null and company <>'' order by company")
    '    Dim DGVCombo As DataGridViewComboBoxColumn = dgvCompanyDiscount.Columns("Company")
    '    For n = 0 To co.Rows.Count - 1
    '        colCompany.Items.Add(co.Rows(n)("Company"))
    '    Next



    '    For n = 0 To dt.Rows.Count - 1

    '        Dim comp As String = dt.Rows(n)("Compy")
    '        Dim lst As String = dt.Rows(n)("PriceList")
    '        Dim Dis1 As String = dt.Rows(n)("disc1p")
    '        Dim Dis2 As String = dt.Rows(n)("discount")
    '        dgvCompanyDiscount.Rows.Add()
    '        dgvCompanyDiscount.Rows(n).Cells(0).Value = comp
    '        dgvCompanyDiscount.Rows(n).Cells(1).Value = lst
    '        dgvCompanyDiscount.Rows(n).Cells(2).Value = Dis1
    '        dgvCompanyDiscount.Rows(n).Cells(3).Value = dis2
    '        'dgvCompanyDiscount.c
    '        '.Item("company", n) = dt.Rows(0)("company")
    '        'dgvCompanyDiscount.Item("pricelist", n) = dt.Rows(0)("pricelist")
    '        'dgvCompanyDiscount.Item("Disc1P", n) = dt.Rows(0)("Disc1P")
    '        'dgvCompanyDiscount.Item("Discount", n) = dt.Rows(0)("Discount")

    '    Next
    'End Sub

End Class