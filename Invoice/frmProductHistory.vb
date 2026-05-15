Imports System.Data.SqlClient

Public Class frmProductHistory
    Private Sub TextBox1_Leae(sender As Object, e As EventArgs) Handles txtiCode.Leave
        ProductHistory()
    End Sub

    Sub ProductHistory()

        MsgBox(dStart.Value.ToString("d"))

        Dim tbl As DataTable = SQLData("select *,sum(QTYIn) over (order by date,type,doc)-sum(QTYOut) over (order by date,type,doc) Bal from (

select 
ps.date,ps.type,ps.doc,a.Subsidary,pd.Description,
sum(case when ps.type='Purchase' then qty else 0 end) qtyin,
sum(case when ps.type='sale' then qty else 0 end) qtyout
from PSProduct ps join PSDetail pd on ps.type=pd.type and ps.doc=pd.doc join coa a on pd.acid=a.id
where prid=(select id from Products where code='04-0401-00') and ps.date > '" & dStart.Value & "' and ps.date< '2020-9-27'
group by ps.date,ps.type,ps.doc,pd.Description,a.Subsidary
) x

")
        MsgBox("done")
    End Sub

    Private Sub txtiCode_Enter(sender As Object, e As EventArgs) Handles txtiCode.Enter
        ProductSearch.ShowDialog()
        txtiCode.Text = ProductSearch.prIDtxt
    End Sub

    Private Sub txtiCode_TextChanged(sender As Object, e As EventArgs) Handles txtiCode.TextChanged

    End Sub

    Private Sub frmProductHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class