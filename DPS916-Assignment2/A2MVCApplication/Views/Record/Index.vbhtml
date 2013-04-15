@ModelType IEnumerable(Of A2MVCApplication.A2Models.RecordModel)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table>
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.UserName)
        </th>
        <th class="adjusted">
            @Html.DisplayNameFor(Function(model) model.Notes)
        </th>
        <th class="adjusted">
            Record Options
        </th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.UserName)
        </td>
        <td class="adjusted">
            @Html.DisplayFor(Function(modelItem) currentItem.Notes)
        </td>
        <td class="adjusted">
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.RecordId}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.RecordId}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.RecordId})
        </td>
    </tr>
Next

</table>
