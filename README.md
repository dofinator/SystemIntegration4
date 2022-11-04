Assignment 4
## Installation 
To run the program install docker desktop and visual studio 2022

## Usage

In the two folders **/Docker-Book-Db** and **/Docker-School-Db** run following command:

 ```docker-compose up-d```

Open **Visual Studio 2022** and do as follows:
* Select the **"Open a project or solution"**
* Select the **SIassignment4.sln** file in the root of the project
* At the top of **Visual Studio 2022** select the search field and type in **Package Manager Console**
* In the console there is a selector named **Default Project:**
* Run following command ```update-database``` in both selected projects:
    * **Default Project: SchoolAPI** and **Default Project: GrpcService**


* Now right click on the **Solution**  

![billede](https://user-images.githubusercontent.com/56348111/199949746-6431cc7a-4f3c-49da-a99c-f9a59b20c133.png)

* Select the option **"Get Startup Projects..."**

* Check the box called **"Multiple startup projects:"**

* For each project select the **Action** to **Start** and click **Ok**

* Click the **Run** button at the top of **Visual Studio 2022**

