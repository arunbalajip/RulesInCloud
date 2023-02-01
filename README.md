# RulesInCloud
Business Rules and Management in the Cloud

# Description
We want to build a business rules creation, management, and serving application in the cloud to decouple the business rules from the application. This would give business users the ability to easily create, and update business rules. Developers can then consume the business for application logic and actions. When a rule changes and is approved no code changes or deployments are necessary, subscribed applications can just start executing the new rules.

# Inspiration
Purpose of a good software architecture is to minimize the human effort of change. Business rules are often hard to change in an application requiring updates to code and deployment. Rules engines help by collecting and simplifying the expression of business rules and application. Originally, we thought to create a software as a service rules workflow engine where users could create and manage business rules. But as we brainstormed, we realized that simplifying the rule creation may be more impactful.

Our inspiration is from scratch programming which is widely used by kids to develop logical thinking. Scratch programming is a block based programming language tool. We used blockly to design and develop a rule engine for business owners. 

# How it will work / How it will be build
## Steps to Run 

We can use this application for multiple use cases. Use case that we chosen is for Microsoft store. Business owners are the users here for our website. We want to help our users to define rules using blocks. Rules defined is to give discount based on the country, total Orders and other fields.  These rules are used by the real customers when they shop Microsoft store.  

1) Goto http://rulesincloud.azurewebsites.net/
2) Load "Discount1" from the load block. 
3) Click on the "Test" tab
``` 
[
  {
    "name": "hello",
    "email": "abcy@xyz.com",
    "creditHistory": "good",
    "country": "India",
    "loyaltyFactor": 3,
    "totalPurchasesToDate": 10000,
    "totalOrders": 5,
    "recurringItems": 2,
    "noOfVisitsPerMonth": 10,
    "percentageOfBuyingToVisit": 15
  }
]
```
4) it returns the rules that matches with the input. 

# References:
[1] Microsoft Rule Engine https://github.com/microsoft/RulesEngine

[2] Blockly https://developers.google.com/blockly/
