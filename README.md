# Windows-Forms-MySQL-CRUD

This project enables users to connect to a MySQL detabase of a specific name and conduct CRUD operations. The entire project is written in C# and it uses Windows Forms for a GUI. You can view tables of database in a DataGridView, and if the user's account type will allow it, user can also make changes to the tables within said DataGridView. User can also view database tables in a graph form. 

The project features a login and register system as well as an account managment system. Accounts are seperated into 3 types:
 - Regular => only allowed to view the database
 - Privileged => full CRUD capabilities
 - Admin => full CRUD capabilities and the only accout type which can set other user's account type
 
By default, after registering an account it is a regular user. User can log in using their username or email. In case the user had forrgotten their password, user take advantage of 'forgot password' option. After clciking on the 'forgot password' option and entering an email, this software will change that particular user's password and send it to user's email. 
 
After succesfully logging in you can also use a 'remember me' function. 'Remember me' function allows the user to log in automatically after starting the program until user chooses to log out manually once in the app. This feature works by storing the login data locally in a text file and data in that file will be encrypted.  
 
Once logged in users can edit some of their unique accout data, such as changeing their password, username or email. 

Changes to database are reccorded and can be viewed within this app.
