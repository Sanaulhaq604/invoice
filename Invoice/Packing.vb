Public Class Packing
    Private Sub Packing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SQLData("select ROW_NUMBER() over (order by ps.id)  RN ,ps.date,a.route,a.Subsidary,ps.prid,ps.doc,p.name,p.UrduName,p.category,p.Company,p.Batch,ps.Qty2,ps.AQty,ps.Qty,case when company in ('fit','fit-o','fit-b','excel') then 'Comp1' else 'Comp2' end CompanyOrder 
from psproduct ps join Products p on ps.prid=p.ID join coa a on ps.acid=a.id --join PsProduct ps2 on ps.type=ps2.type and ps.doc=ps2.doc
where ps.type='sale' and ps.doc=138521
order by CompanyOrder,p.Name,Category")
    End Sub
End Class