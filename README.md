# Student Attendance API
***
The Student Attendance API is an API used for managing students attendance.   

## Table Of Content
1. [General Info] (#general-info)
2. [Technologies] (#technologies)
3. [Installation] (#installation)
4. [Collaboration] (#collaboration)
5. [Technologies] (#genral-info)

## General Info
***
Student Attendance is a system that is used by teachers to capture student attendance and pull attendance reports for students. Reports can be pull daily or in desired period. This system consist of two separate projects: StudentAttendanceAPI and StudentAttendanceUI.
This project is currently in development stage.

## Technologies
***
A list of technologies used within the project:
* [Visual Studio 2019] (https://visualstudio.microsoft.com/downloads/)
* [.Net Core] (https://dotnet.microsoft.com/download/dotnet/3.1)
* [Sql Server Management Studio 18] (https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)


## Installation
***
You need to create a database, update the connection string then run the API.
***
1. git clone https://github.com/Sbu1/StudentsAPI.git using git or download the project direct https://github.com/Sbu1/StudentsAPI
2. Execute studentAttendanceDBscript in sql server which is in the project root folder.
3. Open the project using visual studio.
4. If you are using local sql server you don't need to update your connection string but if you using testing environment please change the server name in the connection string to point to your testing server.
5. Run the project: You should see swagger UI.

## Collaboration
***
To collaborate you need to send an email to sbuddaz@gmail.com stating why you need to collaborate with us and how you will benefits.

## FAQs

## High Level Architecture
![image](https://user-images.githubusercontent.com/47100836/116930109-9d8bfd80-ac5f-11eb-94b1-c940e887f36c.png)

## System Flow
1.You need to create system admin using hidden end point 
  ![image](https://user-images.githubusercontent.com/47100836/116931412-3c652980-ac61-11eb-9176-b80d6eeb5886.png)


2.Login to the system using admin credentials you created in step one and get the token
![image](https://user-images.githubusercontent.com/47100836/116931581-72a2a900-ac61-11eb-8e51-af49f12ccf5c.png)

3. Create a teacher that will be using the system 
![image](https://user-images.githubusercontent.com/47100836/116931876-da58f400-ac61-11eb-86c5-6c19b84dc5ce.png)

4. Login using the teacher credentials and copy the token
![image](https://user-images.githubusercontent.com/47100836/116932030-11c7a080-ac62-11eb-9dfd-e71f9b75d8ec.png)

NB: Please add the token in the header for all requests
![image](https://user-images.githubusercontent.com/47100836/116932397-7daa0900-ac62-11eb-9d58-4347da0f36a9.png)

5. Create a class
![image](https://user-images.githubusercontent.com/47100836/116932880-1c366a00-ac63-11eb-9f6a-739e85c41b40.png)

6. Create a student

![image](https://user-images.githubusercontent.com/47100836/116933345-b7c7da80-ac63-11eb-8188-96fbfda7c593.png)

7.Create student attendance
![image](https://user-images.githubusercontent.com/47100836/116933865-708e1980-ac64-11eb-993d-7fb7b8c9f45f.png)

8. Pull daily report. You can pull previous days reports.

9. Pull terms report.







