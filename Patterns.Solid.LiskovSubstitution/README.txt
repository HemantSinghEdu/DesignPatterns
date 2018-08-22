Liskov Substitution Principle (LSP)
-------------------------------------
This is the L of SOLID principles.

It states that objects of base classes should be replaceable by objects of derived classes.
Basically, a derived class should honor all the expectations associated with the base class. In other words, the child should
not break any promise made by the parent. 

LSP asks for 4 main points to be kept in mind:

	1. Pre-conditions cannot be strengethened in a subtype
	   - In a derived class, don't make the pre-conditions stricter than they are in the base class

	2. Post-conditions cannot be weakened in a subtype
	   - In a derived class, don't make the post-conditions weaker than they are in the base class
 
	3. Invariants of the supertype must be preserved in the subtype
	   - A derived class should not change something that is supposed to be a constant in the parent class

	4. History constraint 


Examples of violations of LSP:

- Bird is a class that has a function fly(). Any function using a Bird reference expects it to fly. We derive a subclass named 
  Penguin. But, a Penguin can't fly(). This is a violation of LSP, as the derived class cannot honor the promise of flying made 
  by the base class . 

		Bird bird = new Penguin();
		bird.fly();					//LSP violation: penguin can't fly. This line will probably do nothing or throw an exception

  --------------------------------------------------------------------------------------------------------------------------

- Test is a class that has a function GetRank(score). It will only accept scores that are > 40 (passing score). We derive a 
  subclass named ToughTest, and we override the GetRank(score) and set the pass cutoff as 50. This is a violation of LSP. 
  ToughTest does not honor the promise made by its parent Test that the passing score is 40, it sets a stricter cutoff of 50.
  We should ensure that the passing score is not stricter than the parent. That is, the pre-condition should not be stricter than
  the pre-condition of the parent.
  
		class Test 
		{ 
			virtual int GetRank(int score)
			{
				if(score >= 40)
				{
					...
				}
				else
				{
					return -1;	//fail:Ok
				}
			}
		}
		class ToughTest : Test
		{ 
			override int GetRank(int score)
			{
				if(score >= 50)		//LSP violation, because of stricter pre-condition
				{
					...
				}
				else
				{
					return -1;		//fail:Ok
				}
			}
		}

		Test test1 = new Test();
		Test test2 = new ToughTest();
		test1.GetRank(40);		// 550	: valid
		test2.GetRank(40);		// -1	: unexpected outcome
  --------------------------------------------------------------------------------------------------------------------------

- You have a Car class with a ShutDown function, which consists of three steps: Brake(), IgnitionOff(), PutInFirstGear()
  You have a NewCar class extending Car class which overrides the ShutDown function, and has these steps: Brake(), IgnitionOff()
  
  class Car 
  {
	virtual void ShutDown()
	{
		Brake();
		IgnitionOff();
		PutInFirstGear();
	}
  }

  class NewCar : Car
  {
	override void ShutDown()
	{
		Brake();
		IgnitionOff();       //third step is missing, weaker post-condition, violation of LSP
	}
  }

  The derived class NewCar is violating the LSP by not including PutInFirstGear() function.
  This can cause issues in certain situations. Let's say that the car was shut down on a slope.

  void Drive(Car car)
  {	
		...
		car.ShutDown();
  }

  When the Drive function is passed an object of NewCar, it will assume that NewCar is in FirstGear, as that is the 
  promise made by the ShutDown function of the Car class. However, since the NewCar is not in FirstGear in reality, it may start
  rolling down the slope and get in an accident.

  The NewCar class is not honoring the expected Shutdown procedure of its parent class Car. It has a weaker Shutdown criteria 
  than its parent. LSP says that we should ensure that the post-condition in child function is not weaker than that in the parent 
  function.
    
  --------------------------------------------------------------------------------------------------------------------------

- You have an Integer class with a Random() function, which returns a random integer. 
  You create a new class NaturalNumber that extends Integer class and overrides Random to return a natural number
  
  class Integer 
  {
		virtual int Random()
		{
			...						//will return a random integer
		}
  }

  class NaturalNumber : Integer
  {
		override int Random()
		{
			...						//will return a random natural number
		}
  }

  This is a violation of LSP, as the derived class will return only a subset of the parent class i.e. only positive numbers.
  This is a case of derived class having stricter pre-conditions than parent class. This can cause unexpected outcomes.
  For example:

  int GetRandomNegativeNumber(Integer integer)
  {
	int randomNum = 0;
	while(randomNum >= 0)
	{
		randomNum = integer.Random();
	}
  }

  If we call this function in the following way:

  Integer integer = new NaturalNumber();
  GetRandomNegativeNumber(integer);		//the while loop inside the function will never break

  The above call to function will never return as the while loop will never break.
  LSP states that a derived class should at least return the results that the parent does. Anything extra is fine, but 
  anything missing is the cause of concern.
      
  --------------------------------------------------------------------------------------------------------------------------

  Based upon the above examples, we can see that LSP asks for 4 main points to be kept in mind:

	1. Pre-conditions cannot be strengethened in a subtype
	   - In a derived class, don't make the pre-conditions stricter than they are in the base class

	2. Post-conditions cannot be weakened in a subtype
	   - In a derived class, don't make the post-conditions weaker than they are in the base class
 
	3. Invariants of the supertype must be preserved in the subtype
	   - A derived class should not change something that is supposed to be a constant in the parent class

	4. History constraint 


LISKOV PRINCIPLE VIOLATION #1
-----------------------------
Problem statement: 
Design a self-driving vehicle software.

public interface IVehicle
{
	void Steer();
	void Accelerate();
	void Brake();
	void SwitchToReverse();
}

Our Drive function uses this interface

void Drive(IVehicle vehicle)
{
	...
	vehicle.SwitchToReverse();
	vehicle.Accelerate();
}

Now, let's say that we implement the IVehicle interface for a bike. 
Since a bike doesn't have a reverse gear, we keep the SwitchToReverse() function empty or throw an exception
This is a violation of LSP

Violating LSP can have negligible, to subtle, to mild, to catastrophic consequences
In our case, if the Drive() function switches to reverse gear and accelerates, our bike may do nothing in the 
best case scenario, or it may move forward and get into an accident.

The main issue here is that IVehicle is not the correct interface for a bike. The Drive() function does not know that if it gets 
a bike object, it cannot switch to reverse. We can try fixing this by checking the type of IVehicle object in Drive() and handling
a bike object differently. But that again brakes the LSP rule, as the Drive function should not have to know the exact object 
being passed.

The best solution is to remove SwitchToReverseGear() from IVehicle, and add it to a new interface IReversable

SOLUTION:
--------------------------------------
public interface IVehicle
{
	void Steer();
	void Accelerate();
	void Brake();
}

public interface IReversable
{
	void SwitchToReverse();
}

public interface IReversableVehicle : IVehicle, IReversable
{
	//inherits from both IVehicle and IReversable
}

void Drive(IVehilce vehicle)  //uses IVehicle: can be used for all vehicles including bikes
{
	...
}

void Drive(IReversableVehicle vehicle)  //uses IReversableVehicle: can be used for reversable vehicles
{
	...
	vehicle.SwitchToReverse();
	vehicle.Accelerate();
}



LISKOV PRINCIPLE VIOLATION #2
-----------------------------
Problem statement: 
Design a self-driving vehicle software. The max speed limit that the software should allow is 150 kmph

public interface IVehicle
{
	void Steer();
	void Accelerate(int currentSpeed);  //added a parameter currentSpeed
	void Brake();
}

public class Vehicle : IVehicle
{
	...
	virtual public void Accelerate(int currentSpeed) 
	{
		Contract.Requires(currentSpeed <= 150);  //check that current speed should not be >150
		if()
	}
}

public class Bike : Vehicle
{
	...
	override public void Accelerate(int currentSpeed) 
	{
		Contract.Requires(currentSpeed <= 100);  //check that current speed should not be >100;
		...
	}
}

In the above example, the Accelerate function of Vehicle class has a pre-condition that the current speed should not
be greater than 150. 
But the bike class (which inherits from Vehicle), further restricts the max speed to 100.
This is a violation of LSP. A derived class should not make pre-conditions stricter. The function below will never 
break out of the while loop because of this violation

void Drive(IVehicle vehicle)  
{
	...
	while(currentSpeed<150)		//this condition will never be true for a bike, an unexpected result of violating the LSP
	{
		currentSpeed = vehicle.Accelerate(currentSpeed);
		...
	}
}