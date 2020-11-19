<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.ascx.cs" Inherits="CapeLibManagementSystem.Content.UserControls.UserLogin" %>

<div style="padding-top:10%">
        <div class="container">   
            <label>Username : </label>   
            <input type="text" placeholder="Enter Username" id="userId" runat="server" required>  
            <label>Password : </label>   
            <input type="password" placeholder="Enter Password" id="passwdId" runat="server" required>  
            <button type="submit" id="submitButton" onclick="submitfunction">Login</button>   
            <button type="button" class="cancelbtn"> Cancel</button>   
        </div>   
</div>