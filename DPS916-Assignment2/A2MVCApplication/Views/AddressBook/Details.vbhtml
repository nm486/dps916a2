@ModelType A2MVCApplication.A2Models.AddressBookModel

@Code
    ViewData("Title") = "Details"
End Code

<h2>Record Details for @Model.AddressBookName</h2>

<p>
    @Html.ActionLink("Create New Record", "Create", "Record", New With {.id = Model.AddressBookId}, Nothing)
</p>

<fieldset>
    <legend>AddressBookModel</legend>
</fieldset>

<br />
<table>
    <tr>
        <th>Record User Name</th>
        <th class="adjusted">Record Notes</th>
        <th class="adjusted">Record Options</th>
    </tr>

@For Each item In Model.Records
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.UserName)
        </td>
        <td class="adjusted">
            @Html.DisplayFor(Function(modelItem) currentItem.Notes)
        </td>
        <td class="adjusted">
            @Html.ActionLink("Details", "Details", "Record", New With {.id = currentItem.RecordId}, Nothing)
            @Html.ActionLink("Edit", "Edit", "Record", New With {.id = currentItem.RecordId}, Nothing)
            @Html.ActionLink("Delete", "Delete", "Record", New With {.id = currentItem.RecordId}, Nothing)
        </td>
    </tr>
Next

</table>

<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.AddressBookId}) |
    @Html.ActionLink("Back to List", "Index")
</p>
