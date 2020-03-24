# AWS Lambda with .NET Core 3.1 runtime

This starter project consists of:
* Function.cs - contains a class with a Main method that starts the bootstrap, and a single function handler method
* aws-lambda-tools-defaults.json - default argument settings for use with Visual Studio and command line deployment tools for AWS
* bootstrap - a Linux bash script that is invoked by the AWS Lambda infrastructure to start the function

The generated Main method is the entry point for the function's process.  The main method wraps the function handler in a wrapper that the bootstrap can work with.  Then it instantiates the bootstrap and sets it up to call the function handler each time the AWS Lambda function is invoked.  After the set up the bootstrap is started.

The generated function handler is a simple method accepting an integer argument that returns a string from a predefined list. Replace the body of this method, and parameters, to suit your needs. 
