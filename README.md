## Read Me ##


### Source ###
Source is stored on Github
https://github.com/doctorcareanywhere/dca.net/


### Build ###
To build web artifacts:

1. Install Ruby
   - Download Ruby installer 2.3.1 http://rubyinstaller.org/downloads/
   - Run installer
   - Check "Add Ruby executables to your PATH" during installation

2. Install Node.js
   - Download Node.js 4.6.1 LTS from https://nodejs.org/en/
   - Run installer
   - Check "Add to PATH" during installation.

3. Python
   - Download Python 2.7.12 https://www.python.org/downloads/
   - Run installer
   - Check "Add python.exe to path" during installation

4. Install Ruby dependencies
   ```
   gem sources -r https://rubygems.org/
   gem sources -a http://rubygems.org/
   gem install compass
   gem install compass-normalize
   gem install compass-rgbapng
   gem install toolkit
   ```

5. Install node dependencies
   - Navigate to DCA.Web
   - Delete node_modules folder
   - Execute the following commands:
   ```
   npm install
   npm install gulp -g
   npm install gulp-cli -g
   ```

6. Compile CSS
   - Make sure you are in DCA.Web 
   - Execute the following commands
     ```
     gulp iconfont
     gulp sass
     ```


### Notes ###
   - We are using Visual Studio task runner to run gulp tasks. Tasks iconfont and sass will run automatically on every build. You can manually start tasks from Task Runner Explorer.
   - Make sure you update position of $(PATH) at the top of locations of external tools in Visual Studio:
     - Go to Tools → Options → Projects and Solutions → External Web Tools
     - Reorder so that $(PATH) is above $(DevEnvDir)\Extensions\Microsoft\Web Tools\External


### Continous Delivery ###
The project is build and deployed using TeamCity: https://tc.doctorcareanywhere.com/teamcity/



### Environments ###
**Development:** 
  - Web: https://devweb.doctorcareanywhere.com/
  - Web API: https://devapi.doctorcareanywhere.com/
  - OAuth: https://devauth.doctorcareanywhere.com/

**QA:**
  - Web: https://testweb.doctorcareanywhere.com/
  - Web API: https://testapi.doctorcareanywhere.com/
  - OAuth: https://testauth.doctorcareanywhere.com/

**UAT:**
  - Web: https://uatweb.doctorcareanywhere.com/
  - Web API: https://uatapi.doctorcareanywhere.com/
  - OAuth: https://uatauth.doctorcareanywhere.com/

**Live:**
  - Web: https://member.doctorcareanywhere.com/
  - Web API: https://api.doctorcareanywhere.com/
  - OAuth: https://auth.doctorcareanywhere.com/




### Monitoring and Error Logging ###
1. Raygun: https://raygun.io
2. Kibana: 
   - Dev/Test/UAT: https://kibdev.doctorcareanywhere.com/app/kibana/
   - Production: https://kib.doctorcareanywhere.com/app/kibana/
