Open Closed Principle
--------------------------
This is the O of SOLID principles.

It states that software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification
Basically, that means that you should write code that doesn't have to be changed every time the requirements change. 
This is achieved via inheritance and polymorphism.

Problem statement: 
A customer asks you to write a program that prints the areas of rectangles. 
He then asks for printing the areas of squares and rectangles.
Then, some days later, he asks for printing the areas of squares, rectangles and circles.
How do you deal with such rapidly changing requirements.

Usual way: 
	- write a class Rectangle with properties length and breadth
	- Similarly, write a class Square and Circle with their respective properties
	- Write a class AreaCalculator with one function PrintArea() that takes an array of shapes and prints each shape's area
		- add a function to get rectangle's area (1st requirement)
		- add a new function to get square's area (2nd requirement)
		- add another function to get circle's area (3rd requirement)

Issue: When the areas to be calculated keep on piling up, the code may become unmanageable 
with new functions being added to the Area class all the time. This is such a scenario where we can see that in future, even 
more complex requirements may come.

Better way: 
	- Create an interface IShape
	- Create classes for Rectangle, Square and Circle, all of them inheriting from IShape
	- Each of the above classes will have their own Area() function to calculate their respective areas
	- Create the AreaCalculator class with only one function PrintArea() that takes an array of IShape objects and prints each shape's area
	- In future, even if more shapes are added, the AreaCalculator class will not be disturbed



