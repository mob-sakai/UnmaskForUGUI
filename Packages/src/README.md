Unmask For UGUI
===

Reverse mask for uGUI element in Unity.

![](https://user-images.githubusercontent.com/12690315/51747120-e1d8dc80-20eb-11e9-952e-a67915af1294.png)

[![](https://img.shields.io/npm/v/com.coffee.unmask?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.coffee.unmask/)
[![](https://img.shields.io/github/v/release/mob-sakai/UnmaskForUGUI?include_prereleases)](https://github.com/mob-sakai/UnmaskForUGUI/releases)
[![](https://img.shields.io/github/release-date/mob-sakai/UnmaskForUGUI.svg)](https://github.com/mob-sakai/UnmaskForUGUI/releases)
[![](https://img.shields.io/github/license/mob-sakai/UnmaskForUGUI.svg)](https://github.com/mob-sakai/UnmaskForUGUI/blob/main/LICENSE.txt)
[![PRs Welcome](https://img.shields.io/badge/PRs-welcome-orange.svg)](http://makeapullrequest.com)
[![](https://img.shields.io/twitter/follow/mob_sakai.svg?label=Follow&style=social)](https://twitter.com/intent/follow?screen_name=mob_sakai)

![](https://img.shields.io/badge/Unity%205.x-supported-blue.svg)
![](https://img.shields.io/badge/Unity%202017.x-supported-blue.svg)
![](https://img.shields.io/badge/Unity%202018.x-supported-blue.svg)
![](https://img.shields.io/badge/Unity%202019.x-supported-blue.svg)
![](https://img.shields.io/badge/Unity%202020.x-supported-blue.svg)
![](https://img.shields.io/badge/Unity%202021.x-supported-blue.svg)

![](https://img.shields.io/badge/Universal%20RP-supported-blue.svg)  

<< [Description](#description) | [WebGL Demo](#demo) | [Installation](#installation) | [Usage](#usage) | [Contributing](#contributing) >>



<br><br><br><br>

## Description

Unmask provides the following features:
1. Reverse mask
2. Ray through the unmasked rectangle
3. Following another object
4. Support nesting

| Component | Features | Screenshot |
|-|-|-|
|**Unmask**|Reverse masking for parent Mask component.<br><br>**Fit Target / Fit On Late Update:** Fit graphic's transform to target transform on LateUpdate.<br>**Only For Children:** Unmask affects only for children.<br>**Show Unmask Graphic:** Show the graphic that is associated with the unmask render area.|<img src="https://user-images.githubusercontent.com/12690315/51745704-0e3e2a00-20e7-11e9-8da8-5abb1c5193bc.png" width="600px">|
|**UnmaskRaycastFilter**|The ray Passes through the unmasked rectangle.<br>You can click on the unmasked button on the back side.|<img src="https://user-images.githubusercontent.com/12690315/51745958-ebf8dc00-20e7-11e9-8cfc-8174e6ab2b7c.png" width="600px">|



<br><br><br><br>
## Demo

[WebGL Demo](http://mob-sakai.github.io/UnmaskForUGUI)

![demo](https://user-images.githubusercontent.com/12690315/46986251-4e296480-d129-11e8-8e3a-2bb0e5fbe533.gif)



<br><br><br><br>

## Installation

### Requirement

![](https://img.shields.io/badge/Unity%205.x-supported-blue.svg)
![](https://img.shields.io/badge/Unity%202017.x-supported-blue.svg)
![](https://img.shields.io/badge/Unity%202018.x-supported-blue.svg)
![](https://img.shields.io/badge/Unity%202019.x-supported-blue.svg)
![](https://img.shields.io/badge/Unity%202020.x-supported-blue.svg)
![](https://img.shields.io/badge/Unity%202021.x-supported-blue.svg)

![](https://img.shields.io/badge/Universal%20RP-supported-blue.svg)

### Using OpenUPM

This package is available on [OpenUPM](https://openupm.com).  
You can install it via [openupm-cli](https://github.com/openupm/openupm-cli).
```
openupm add com.coffee.unmask
```

### Using Git

Find the manifest.json file in the Packages folder of your project and edit it to look like this:
```
{
  "dependencies": {
    "com.coffee.unmask": "https://github.com/mob-sakai/UnmaskForUGUI.git",
    ...
  },
}
```

To update the package, change suffix `#{version}` to the target version.

* e.g. `"com.coffee.unmask": "https://github.com/mob-sakai/UnmaskForUGUI.git#2.0.0",`

Or, use [UpmGitExtension](https://github.com/mob-sakai/UpmGitExtension) to install and update the package.

### For Unity 2018.2 or earlier

1. Download a source code zip file from [Releases](https://github.com/mob-sakai/UnmaskForUGUI/releases) page
2. Extract it
3. Import it into the following directory in your Unity project
   - `Packages` (It works as an embedded package. For Unity 2018.1 or later)
   - `Assets` (Legacy way. For Unity 2017.1 or later)



<br><br><br><br>

## How to play demo

- For Unity 2019.1 or later
  - Open `Package Manager` window and select `UI Unmask` package in package list and click `Demo > Import in project` button
- For Unity 2018.4 or earlier
  - Click `Assets/Samples/UI Unmask/Import Demo` from menu

The assets will be imported into `Assets/Samples/UI Unmask/{version}/Demo`.  
Open `UIUnmask_Demo` scene and play it.



<br><br><br><br>

## Usage

Create Object From Menu (`GameObject > UI > Unmask > ***`)

|Menu|Screenshot|
|--|--|
|Tutorial Button|![](https://user-images.githubusercontent.com/12690315/123756826-4a00fd80-d8f8-11eb-8fb4-5d4399a3f907.png)|
|Iris Shot|![](https://user-images.githubusercontent.com/12690315/123756809-45d4e000-d8f8-11eb-8bc9-767b81b8da42.png)|



<br><br><br><br>

## Example of using

| Case | Description |Screenshot |
|-|-|-|
|Unmasked text|Black screen is cut out with unmasked text.|![](https://user-images.githubusercontent.com/12690315/46914021-c6c9dd00-cfd2-11e8-9698-6332bac8fef5.png)|
|Hole|Black screen is cut out with unmasked Image.|![](https://user-images.githubusercontent.com/12690315/46985696-9b580700-d126-11e8-9b4a-3d66180c9562.png)|
|Tutorial button|In tutorial, only specific button can be pressed.|![](https://user-images.githubusercontent.com/12690315/46983810-30560280-d11d-11e8-86d5-b25117740df4.png)|
|Iris in/out|Transition effect with iris in/out.|![](https://user-images.githubusercontent.com/12690315/46983811-30560280-d11d-11e8-8d81-b38679cf9970.gif)|



<br><br><br><br>

## Contributing

### Issues

Issues are very valuable to this project.

- Ideas are a valuable source of contributions others can make
- Problems show where this project is lacking
- With a question you show where contributors can improve the user experience

### Pull Requests

Pull requests are, a great way to get your ideas into this repository.  
See [CONTRIBUTING.md](/../../blob/main/CONTRIBUTING.md) and [develop](https://github.com/mob-sakai/UnmaskForUGUI/tree/develop) branch..

### Support

This is an open source project that I am developing in my spare time.  
If you like it, please support me.  
With your support, I can spend more time on development. :)

[![](https://user-images.githubusercontent.com/12690315/50731629-3b18b480-11ad-11e9-8fad-4b13f27969c1.png)](https://www.patreon.com/join/2343451?)  
[![](https://user-images.githubusercontent.com/12690315/66942881-03686280-f085-11e9-9586-fc0b6011029f.png)](https://github.com/users/mob-sakai/sponsorship)




<br><br><br><br>

## License

* MIT
* © UTJ/UCL



## Author

[mob-sakai](https://github.com/mob-sakai)
[![](https://img.shields.io/twitter/follow/mob_sakai.svg?label=Follow&style=social)](https://twitter.com/intent/follow?screen_name=mob_sakai) 



## See Also

* GitHub page : https://github.com/mob-sakai/UnmaskForUGUI
* Releases : https://github.com/mob-sakai/UnmaskForUGUI/releases
* Issue tracker : https://github.com/mob-sakai/UnmaskForUGUI/issues
* Change log : https://github.com/mob-sakai/UnmaskForUGUI/blob/main/CHANGELOG.md
