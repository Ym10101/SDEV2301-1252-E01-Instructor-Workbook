using L08_Demo01;

Dog currentDog = new Dog();
currentDog.Name = "Fido"; // inherited property
Console.WriteLine(currentDog);
currentDog.Eat(); // inherited method
currentDog.Bark(); // Dog's own behavior

// Polymorphism in action
Animal firstAnimal = new Dog(); // Animal reference, Dog object
Animal secondAnimal = new Cat();
firstAnimal.Speek(); // Calls Dog's overridden Speek()
secondAnimal.Speek(); // Calls Cat's overridden Speek()