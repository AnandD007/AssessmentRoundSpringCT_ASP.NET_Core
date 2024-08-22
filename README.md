# AssessmentRoundSpringCT_ASP.NET_Core

### Implemented Below All Mentioned Implementation within WebAPI and applied all the Condtions
1. Add a Course [Name, Professor Name, Description]
2. Add a Student [Name, Email, Phone]
3. Assign a Student to one or more Courses
4. List Students [Name, Email, Phone, Course Enrolled (comma separated string)]
5. Delete a given Course
6. Get a list of Students data by Course name
7. Create a Login API with any authentication mode. Unless the user hits this API first, others should 
not be accessible, giving a 401 UnAuthorized Access response.

### Implementation Apprach:
- Used Code First Approach to Work and Handle the database using Dotnet Entity Framework Database Migration.
- Created a relational database for storing student and course information by using Entity Framework and Written all table quries using Linq.
- Student and Courses will be Many-to-Many within contextDB.
- Implemented all RESTful APIs for each of the endpoints mentioned above.
- Implemented Proper error handling.
- Used Swagger for testing the APIs.

#### For Login Authentication: (Implemented Authentication using Jwt Bearer package to check and create Jwt tokens)
- Login Username: teststudentuser
- Login Password: studentpassword
