@Code
    ViewData("Title") = "Home Page"
End Code

@section featured
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1>@ViewData("Title").</h1>
                <h2>@ViewData("Message")</h2>
            </hgroup>
            <p>
                To get started, click on the Address Books navigation link on the top right, or click <a href="./AddressBook/Index">here.</a>
                <br />
                Below you can read a quick step-by-step tutorial on how to use our Address Book Manager website.
            </p>
        </div>
    </section>
End Section

<h3>Heres how to use our Address Book Manager website:</h3>
<ol class="round">
    <li class="one">
        <h5>Getting Started - Work with an address book</h5>
        Once on the Address Books Index page, you can create a new address book or work with an existing one in the address book list.  You can
        update an address book's name using the edit function, or go view an address book's records with the View function.
    </li>

    <li class="two">
        <h5>View and Work with an address book's records</h5>
        Once inside an address book, you will see all of the existing records, if any, for it.  You can view, edit, and delete records and create new 
        records.
    </li>

    <li class="three">
        <h5>Modify record details</h5>
        You can add any number of email addresses, physical addresses, phone numbers, and cellphone numbers to a user's record.
        You can also write a note for a specific record as well.
    </li>
</ol>
