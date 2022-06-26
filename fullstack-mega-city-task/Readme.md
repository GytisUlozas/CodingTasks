## Watt a City

Nortal has agreed to build IT infrastructure for the brand new Mega City. The city is going to be the next world wonder. For the city to be smart a lot of programming must be done. Your team’s first task is to build a system for managing Mega’s energy needs. This system is going to control how much energy will be forked from the main power grid to different buildings in the city. The poor engineering of the system might result in a complete meltdown of this marvelous city, so make sure to bring you A-game. Once you have completed programming the system it must be faster than Usain Bolt and more robust than Nokia 3310. Break a leg.

## Setup

## .Net Application

It uses .Net 6 (It is verified with VS 2022).

## Angular Application

To start the application, you need Node.js version 14+. You can download it from here https://nodejs.org/en/download/.

Run ‘npm install’ in the frontend folder. After it has finished, you can execute ‘npm run start’ to run the Angular application.

## Assignment

Your teammate Juku started implementing the application, but it still needs a lot of work. He left you three user stories that describe changes and improvements you need to make. There are TODOs in the codebase but do not solely rely on them.

### Story 1: Finish update building implementation

Navigate to http://localhost:4200/building/1. This view is complete so that clicking the 'Save' button updates the building.

**Add building index validation** - Index must start with NO. For example, the following are valid indexes - NO123, NOEE20. If the index is invalid the display message ‘Index has to start with NO’ below the input field.

**Add building energy unit validation** - Energy units are not allowed to exceed maximum energy units. If they do display the message ‘This building can stake a maximum of X units.'

**Disable editing of sector code and energy unit max** - Disable sector code field out. Do not let users modify either of these values. Both values are assigned during initial saving and won’t be updatable later.

### Story 2: Implement create building view

Implement a view for creating new buildings. This view should locate at http://localhost:4200/building/new. This view should be identical to the edit building view with two following exceptions:

**Enable sector code field** - This field should be enabled only during the initial save.

**Add maximum energy unit field** - This field should be visible only during the initial save.

### Story 3: Improvements to building list view

The building list view locates at http://localhost:4200/buildings.

**Add update building button** – Add this button to every table row. When clicked, navigate the user to building editing view.

**Add create building button** – Add this button above the table. When clicked, navigate the user to create a new building view.

Do you have questions?

As the forum is open (https://nortal.com/careers/summeruniversity-lt-22/net-task-discussion-lt-2022/), read the previous answers and if you didn't find the answer, ask your own. Our specialists keep an eye on the forum daily and answer your questions as soon as possible.