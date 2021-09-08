# MarketPlaceCoreTeamCaseStudy-IsaacHolden

What potential improvements could be made to the code?

- All properties and methods should be commented!

- CreditCardResponseController.Get(Applicant applicant) signature uses Applicant type in parameter instead of the IApplicant interface. This is because System.Text.Json.Serialization deserialization throws an exception when trying to deserialize the JSON passed to the method if an Inteface is used. A custom deserialization implementation might be needed, or perhaps using Newtonsoft's deserialization might be possible.

- An additional layer of abstraction between the application and the database layer would be preferred, to make it easier to quickly drop in a different database engine while leaving the current Mongo implementation complete.

- Namespace/folder structure of the DataLibrary and naming of types could be improved to make it clearer as to what the types are for/do.