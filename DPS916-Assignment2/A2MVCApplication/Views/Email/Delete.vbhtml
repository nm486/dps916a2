@ModelType A2MVCApplication.A2Models.EmailModel

@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
<fieldset>
    <legend>EmailModel</legend>

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
@Using Html.BeginForm()
    @<p>
        <input type="submit" value="Delete" /> |
        @Html.ActionLink("Back to List", "Index")
    </p>
End Using
