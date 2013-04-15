﻿@ModelType A2MVCApplication.A2Models.RecordModel

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>RecordModel</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.AddressBook.AddressBookId)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.AddressBook.AddressBookId)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Notes)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Notes)
    </div>
</fieldset>
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
