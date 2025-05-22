# TechnicalAssessment

i use Swagger for the api so i can check even without the front end
also use Bogus



here for the answer on question
in the part 2

1. Azure Integration: What Azure services would you recommend for a secure API
gateway that connects multiple identity data sources to a centralized API? How
would you handle authentication?
answer:

* Microsoft Entra ID (formerly Azure Active Directory)

* OAuth 2.0 with Microsoft Entra ID
Client Authentication: Configure APIM to use OAuth 2.0, allowing clients to authenticate via Entra ID. This setup supports SSO and integrates seamlessly with other Azure services
*Token Validation: APIM can validate JWT tokens issued by Entra ID, ensuring that only authorized requests are processed.



2. Data Access: How would you optimize SQL queries when dealing with large
volumes of identity data in SQL Server? Provide a specific example of a
technique you've used.


* Non-Clustered Indexes: Create non-clustered indexes on columns used in WHERE, JOIN, and ORDER BY clauses to speed up data retrieval.

* Limit Data Retrieval
* Avoid using SELECT *; instead, specify only necessary columns to reduce data transfer and processing overhead.

* Employ Common Table Expressions (CTEs) for Complex Queries

* Use Parameterized Queries and Stored Procedures


3. Security: How would you implement secure handling of personally identifiable
information (PII) in an Angular and .NET Core application, both for data in transit
and at rest?

* use https
* for BAckend use Encapsulation (private , public)
*JWT toket or Authorization
*also you can refactor the api to hide parameter


4. DevOps: Briefly describe how you would set up CI/CD for this application stack
(Angular, .NET Core) in an Azure environment.

*you can use git create main branch (also we can use jira for the ticket and task instead of naming a branch per developer use the ticket as a branch)
*always Back everything
*always pull before doing something
*seperate the BE and FE for better debugging