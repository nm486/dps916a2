﻿@ModelType A2MVCApplication.A2Models.EmailModel

@Code
    ViewData("Title") = "Create"
End Code

<h2>Add Email Address For @ViewData("username")</h2>

@Using Html.BeginForm()

    @<fieldset>
        <legend>EmailModel</legend>

        @Html.Hidden("RecordId", ViewData("id"))
       
        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Text)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Text)
            <br />
            @Html.ValidationMessageFor(Function(model) model.Text)
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to Record", "Edit", "Record", New With {.id = ViewData("id")}, Nothing)
</div>

@Section Scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section
