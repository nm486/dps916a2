@ModelType A2MVCApplication.A2Models.RecordModel

@Code
    ViewData("Title") = "Details"
End Code

<h2>Record Details</h2>
<br />
<fieldset>
    <legend>RecordModel</legend>

    <div class="display-field">
        @Html.DisplayFor(Function(model) model.AddressBook.AddressBookId)
    </div>
    <br />
    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.EmailAddresses)
    </div>
    <div class="display-field">
        @For Each item In Model.EmailAddresses
            Dim currentItem = item
                @Html.DisplayFor(Function(modelItem) currentItem.Text)
                @<br />
        Next
    </div>
    <br />
    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.PhoneNumbers)
    </div>
    <div class="display-field">
        @For Each item In Model.PhoneNumbers
            Dim currentItem = item
                @Html.DisplayFor(Function(modelItem) currentItem.Text)
                @<br />
        Next
    </div>
    <br />
    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.CellPhoneNumbers)
    </div>
    <div class="display-field">
        @For Each item In Model.CellPhoneNumbers
            Dim currentItem = item
                @Html.DisplayFor(Function(modelItem) currentItem.Text)
                @<br />
        Next
    </div>
    <br />
    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Addresses)
    </div>
    <div class="display-field">
        @For Each item In Model.Addresses
            Dim currentItem = item
                @Html.DisplayFor(Function(modelItem) currentItem.Text)
                @<br />
        Next
    </div>
    <br />
    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Notes)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Notes)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.RecordId}) |
    @Html.ActionLink("Back to Address Book", "Details", "AddressBook", New With {.id = Model.AddressBookId}, Nothing)
</p>
