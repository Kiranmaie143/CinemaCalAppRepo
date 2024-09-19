CinemaCalApp
1. How to run the project locally locally?
  created application in .net core and React template to simplify the app and userfriendly
  a.clone the repo using git clone and run npm install on client code
  b.open code in vs and press F5 backend will run on https://localhost:7200/swagger/index.html and frontend on https://localhost:5173/
  
2. What is the overall structure structure of your code?
   a. Backend cinemcalapp.server has model,dataconext,service,middleware,repository and controller.Floowed seperation of concerns here
   b. Frontend cinmecalapp.client created component expenselist.jsx and css with responsiveness.Managed react state using useState and useEffect.

3.How do you manage state state in your application? Why did you choose this solution?
 a. useState: Holds the list of expenses (expenses) and tracks the state of form input for adding new expenses.
 b. useEffect: Used to fetch the initial list of expenses from the backend when the component mounts.
Reason for Choosing This Solution: React’s useState and useEffect are the simplest and most effective ways to manage local component state in smaller apps. They are lightweight, provide the necessary reactivity, and don't require complex setup. Given the size and scope of the app, more sophisticated state management libraries (like Redux) were not necessary.

4.How does your approach for precise number calculations precise number calculations work?
 a. Decimal Library: Use libraries like decimal.js for precise arithmetic operations.
 b. Conversion to String: Convert decimal results to strings when sending them to the backend to avoid precision issues.

5. What „tasks“ did you have on your mind? How did you break down the different 
deliverables?
  a. Create Expense Management API backend with tasks like creating model,dataconext,service,repsoitory,and cotroller with end points
  b. Add exception handling
  c. create frontend for component to handle data input and userinterface
  d. handle precise calculations and responsiveness

Throughout the development, I followed these principles:

Separation of Concerns: I focused on separating business logic (service layer) from data access logic (repository layer) in the backend to ensure maintainability and testability.

Component-Based Design: React’s component model allows for modular, reusable UI components, making the app easier to expand later.

Responsiveness: CSS was structured to ensure that the app looks good across different screen sizes, using flexbox and media queries.

Exception Handling: I introduced middleware in the ASP.NET Core application to ensure that errors are caught and returned in a user-friendly manner, instead of crashing the app.

Efficiency: Tried to minimize API calls and ensure the app is responsive by preloading the data and updating the UI as soon as new expenses are added.
  