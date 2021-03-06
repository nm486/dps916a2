﻿@ModelType IEnumerable(Of A2MVCApplication.A2Models.EmailModel)

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
            @Html.DisplayNameFor(Function(model) model.Record.UserName)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Text)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Record.UserName)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.Text)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = currentItem.EmailId}) |
            @Html.ActionLink("Details", "Details", New With {.id = currentItem.EmailId}) |
            @Html.ActionLink("Delete", "Delete", New With {.id = currentItem.EmailId})
        </td>
    </tr>
Next

</table>
