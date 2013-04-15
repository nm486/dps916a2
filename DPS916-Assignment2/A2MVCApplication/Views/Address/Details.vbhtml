@ModelType A2MVCApplication.A2Models.AddressModel

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>AddressModel</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Record.UserName)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Record.UserName)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Text)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Text)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.AddressId}) |
    @Html.ActionLink("Back to List", "Index")
</p>
