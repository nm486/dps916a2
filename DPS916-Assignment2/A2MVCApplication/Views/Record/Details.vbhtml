@ModelType A2MVCApplication.A2Models.RecordModel

@Code
    ViewData("Title") = "Details"
End Code

<h2>Record Details</h2>
<br />
<fieldset>
    <legend>RecordModel</legend>

    <div class="display-field">
        @Html.LabelFor(Function(model) model.AddressBook.AddressBookId)
    </div>
    <br />
    <div class="display-label">
        @Html.LabelFor(Function(model) model.EmailAddresses)
    </div>
    <div class="display-field">
        @If Model.EmailAddresses.Count = 0 Then
            @<span>No email addresses in record.</span>
        End If
        @For Each item In Model.EmailAddresses
            Dim currentItem = item
                @Html.DisplayFor(Function(modelItem) currentItem.Text)
                @<br />
        Next
    </div>
    <br />
    <div class="display-label">
        @Html.LabelFor(Function(model) model.PhoneNumbers)
    </div>
    <div class="display-field">
        @If Model.PhoneNumbers.Count = 0 Then
            @<span>No phone numbers in record.</span>
        End If
        @For Each item In Model.PhoneNumbers
            Dim currentItem = item
                @Html.DisplayFor(Function(modelItem) currentItem.Text)
                @<br />
        Next
    </div>
    <br />
    <div class="display-label">
        @Html.LabelFor(Function(model) model.CellPhoneNumbers)
    </div>
    <div class="display-field">
        @If Model.CellPhoneNumbers.Count = 0 Then
            @<span>No cell phone numbers in record.</span>
        End If
        @For Each item In Model.CellPhoneNumbers
            Dim currentItem = item
                @Html.DisplayFor(Function(modelItem) currentItem.Text)
                @<br />
        Next
    </div>
    <br />
    <div class="display-label">
        @Html.LabelFor(Function(model) model.Addresses)
    </div>
    <div class="display-field">
        @If Model.Addresses.Count = 0 Then
            @<span>No addresses in record.</span>
        End If
        @For Each item In Model.Addresses
            Dim currentItem = item
                @Html.DisplayFor(Function(modelItem) currentItem.Text)
                @<br />
        Next
    </div>
    <br />
    <div class="display-label">
        @Html.LabelFor(Function(model) model.Notes)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Notes)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.RecordId}) |
    @Html.ActionLink("Back to Address Book", "Details", "AddressBook", New With {.id = Model.AddressBookId}, Nothing)
</p>
    