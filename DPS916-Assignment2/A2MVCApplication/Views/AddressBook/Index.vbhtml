@ModelType IEnumerable(Of A2MVCApplication.A2Models.AddressBookModel)

@Code
    ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New Address Book", "Create")
</p>
<table>
    <tr>
        <th>Book ID</th>
        <th class="adjusted">Book Name</th>
        <th class="adjusted">No. of Records</th>
        <th class="adjusted">Options</th>
    </tr>

@For Each item In Model
    Dim currentItem = item
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) currentItem.AddressBookId)
        </td>
        <td class="adjusted">
            @Html.DisplayFor(Function(modelItem) currentItem.AddressBookName)
        </td>
        <td class="adjusted">
            @Html.DisplayFor(Function(modelItem) currentItem.Records.Count)
        </td>
        <td class="adjusted">
            @Html.ActionLink("View Book", "Details", New With {.id = currentItem.AddressBookId}) |
            @Html.ActionLink("Edit Book", "Edit", New With {.id = currentItem.AddressBookId}) |
            @Html.ActionLink("Delete Book", "Delete", New With {.id = currentItem.AddressBookId})
        </td>
    </tr>
Next

</table>
