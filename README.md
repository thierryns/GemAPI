# GemAPI

Objectives:
https://github.com/gem-spaas/powerplant-coding-challenge

PRE-REQ
- Visual Studio 2022 Community Edition
- ensure you have .Net core SDK 3.1.22 installed
- installed Docker is installed and ready to be used (I have used Windows 10 + Docker Desktop 4.3.1)

HOW TO USE
1) Download source code and RUN in DEBUG MODE in Visual Studio
- clone the repo and open it with Visual Studio 2019 (I used VS2022 Community Edition)
- run in IIS Express then it will by default load port 8888 (accept SSL warning if any)
- run in Docker (hopefully your installation has Docker Support added)
2) Once running, it loads a SWAGGER page. Expand the block named Energy
3) The Energy block contains one POST method called productionplan
4) Expand productionplan end point and click on TRY OUT
5) copy and example payload from one of the 3 examples supplied and paste it in the Request Body
6) Click Execute and you shall see the expected output

HOW TO USE (DOCKER)
1) ...
In the run dropdown, where IIS EXpress was previously selected, now select Docker instead
2) Once running, it loads a SWAGGER page but on a different HTTP port (provided from the docker container)


