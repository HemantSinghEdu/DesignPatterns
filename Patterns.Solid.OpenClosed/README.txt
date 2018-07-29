Open Closed Principle
--------------------------
This is the O of SOLID principles.

It states that software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification
Basically, that means that you should write code that doesn't have to be changed every time the requirements change. 
This is achieved via inheritance and polymorphism.

Problem statement: 
A customer asks you to write a program that creates a list of cars. He then asks you to writ a function to filter all SUVs. 
Then, some days later, he asks you to filter all red cars. Few more days later, he asks you to filter all red SUVs. 
How do you deal with such rapidly changing requirements.

Usual way: 
	- write a class Car for car with properties such as color, car type etc.
	- write a class CarFilter for filtering cars
		- add a function to filter by color (1st requirement)
		- add a new function to filter by type (2nd requirement)
		- add another function to filter by color and type (3rd requirement)

Issue: When the conditions for filtering the cars keep on piling up with And/or/not combinations, the code may become unmanageable 
with new functions being added to the CarFilter class all the time. This is such a scenario where we can see that in future, even 
more complex requirements may come.

Better way: Use the specification pattern in this case to enforce the open-close principle
	- Create a Car class
	- Create an interface ISpecification with only one method - IsSatisfied(Car c) - this will return true/false based 
	  on a particular condition for a car
	- Create an interface IFilter with only one method - Filter(List<Car> cars, ISpecification spec) - this will 
	  filter cars that return true for IsSatisfied function of the specification
	- Create ColorSpecification and CarTypeSpecification that inherit from ISpecification,  
	  and implement the IsSatisfied() method for each of them
	- Next, create an AndSpecification that combines ColorSpecification and CarTypeSpecification in its IsSatisfied function
	- Similarly, if a new requirement comes for filtering the cars, we can create new specifications.
	- Create a class CarFilter that inherits from IFilter and implement the Filter() function
	- Notice that even if new specifications are created, the Car and CarFilter classes will not be modified, the specification 
	  pattern will ensure that CarFilter can be extended for as many requirements as needed, without any need for modification


Note: Use this pattern only if there's no other option and the requirements are piling on and on. The Specification pattern 
is considered a bit of an anti-pattern, as it introduces a lot of unnecessary complexity in the code, and is not intuitive.



