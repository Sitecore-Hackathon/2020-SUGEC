# Sitecore Hackathon NEW Website

## Summary

**Category:** Sitecore Hackathon Website – This idea is sooo meta! Several years have passed with the current version and it’s in need of a refresh.

The current Sitecore hackathon website is simple and we could say a little bit boring. We dedided to rebuild and redesign the site to make it more engaging to the users. The Sitecore Experience Platform to host the content of the new site and manage the different components where it's easy to manage content and provide relevant information. 

## Pre-requisites

Please make sure you have the following requirements installed:

- Sitecore 9.3 (Initial Release)

## Installation

Please follow this instructions to install this module:

1. Use the Sitecore Installation wizard to install the [package](Resources/Hackathon2020-SUGEC-1.0.zip)
   - The package contains config and binaries files so pool recycle is expected. 
2. Publish site (smart mode) when the site loads again.

For more details, read our [Installation Guide](Installation_Guide.md)

## Configuration

You don't need to configure anything else, the site is ready to be used once it's correctly installed.
No extra configurations are needed.
If you have more than one site on your Sitecore instance, you could modify the SiteDefinitions.config file located at App_Config\Include\Project\ where you can add hostname to resolve as needed. 

```xml
<?xml version="1.0"?>
<!--
  Purpose: Configuration settings for the NEW Sitecore Hackathon website
-->
<configuration xmlns:patch="http://www.sitecore.net/xmlconfig/">
  <sitecore>
    <sites>
      <site name="hackathon" patch:before="site[@name='website']"
            virtualFolder="/"
            physicalFolder="/"
            rootPath="/sitecore/content/hackathon"
            startItem="/home"
            database="web"
            domain="extranet"
            allowDebug="true"
            cacheHtml="true"
            htmlCacheSize="50MB"
            enablePreview="true"
            enableWebEdit="true"
            enableDebugger="true"
            disableClientData="false"/>
    </sites>
  </sitecore>
</configuration>
```

## Usage

First, let's make sure the website is up and running. Go to https://yourdomain/ and see if the Sitecore Hackathon home page is displayed.

![Homepage](images/image1.png?raw=true "Homepage")

You can browse other pages to make sure everything is working as expected. 

Now we can check how it the site is structured:

![Sitecore](images/image2.png?raw=true "Sitecore")

We have few pages to manage information, upcoming and past events and other generic pages. 

If you go to the list of events, you will see when a current event is happening and actual users can register to that event:

![Events](images/image3.png?raw=true "Events")

When you visit an event page where the registration is still open, you will be able to Register to that event by clicking on the "Register Now!" button.

![Register](images/image4.png?raw=true "Register")

 You will be redirected to the registration page where you can subscribe up to 3 team members. Do not forget to add a Team name.
 
![Register](images/image5.png?raw=true "Register")

The registration goes to a workflow process where a collaborator needs to review it and approve so the application can be published/registered.

![Register](images/image7.png?raw=true "Register")
   

There is also a section to manage Judges for the event:

![judges](images/image8.png?raw=true "Judges")
![judges](images/image9.png?raw=true "Judges")

When an event has been completed, we can also display the winner teams

![winners](images/image10.png?raw=true "winners")

NOTE: The following features are planned for future release:

- User and Team profiles.
- News or blog posts. 
- Newsletter subcription. 


That's everything you need to know about the complexity of this site!

![sugec](images/image11.png?raw=true "sugec")



## Video

Here is our presentation of this module. 

[direct link](resources/Sitecore%20Hackathon%202019.mp4) to the video. 

[![Sitecore Hackathon SUGEC](https://img.youtube.com/vi/sffI8ac8hPU/0.jpg)](https://youtu.be/1qN9hxwi5WE)
