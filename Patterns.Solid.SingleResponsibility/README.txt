Single Responsibility
--------------------------
This is the S of SOLID principles.

It states that a class should only be responsible for doing one thing.
This principles helps us enforce separation of concerns.

Problem statement:
Write a program to perform read/write operations on employee data.


Usual way: Create an Employee class. Also create two functions Load() and Save() to read/write the employee object. And two additional functions for date conversion.

Issue: Writing read/write operations in the employee class itself goes against the principle of Single Responsibility

Better way: Single Responsibility: Create an Employee class. Also create two other classes, one named Persistance that performs Save and Load, and another named DateConverter for date parsing logic
