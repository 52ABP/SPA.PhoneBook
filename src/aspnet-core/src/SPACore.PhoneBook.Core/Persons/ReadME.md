using SPACore.PhoneBook.PhoneBooks.Persons;

/**
 
推荐将文件后缀更改为.md格式

#代码生成器(ABP Code Power Tools )使用说明文档


> ABP Code Generator 是基于ABP（ASP.NET Boilerplate）框架制作的代码生成器，
可以用于大家在日常开发过程中节约时间，把更多的精力放于业务逻辑的处理中。

>欢迎您使用 ABP Code Generator ，重新开发的代码生成器，
支持.net framework和.net core 双版本。
开发代码生成器的初衷是为了让大家专注于业务开发，
而基础设施的地方，由代码生成器实现，节约大家的实现。
实现提高效率、共赢的局面。 

欢迎到：[Github地址](https://github.com/52ABP/52ABP.CodeGenerator) 提供您的脑洞，
如果合理的我会实现哦~
 

## 广告

52ABP官方网站：[http://www.52abp.com](http://www.52abp.com)
 
项目展示地址: [http://www.yoyocms.com/](http://www.yoyocms.com/)

博客地址：[http://www.cnblogs.com/wer-ltm/](http://www.cnblogs.com/wer-ltm/)

代码生成器帮助文档：[http://www.cnblogs.com/wer-ltm/p/8445682.html](http://www.cnblogs.com/wer-ltm/p/8445682.html)

【ABP代码生成器交流群】：104390185（收费）
[![52ABP .NET CORE 实战群](http://pub.idqqimg.com/wpa/images/group.png)](http://shang.qq.com/wpa/qunwpa?idkey=3f301fa3101d3201c391aba77803b523fcc53e59d0c68e6eeb9a79336c366d92)

【52ABP .NET CORE 实战群】：633751348 (免费)
 [![52ABP .NET CORE 实战群](http://pub.idqqimg.com/wpa/images/group.png)](https://jq.qq.com/?_wv=1027&k=5pWtBvu)


### 需要进行配置的地方:

**配置Automapper** :

复制以下代码到Application层下的： PhoneBookApplicationModule.cs
中的 PreInitialize 方法中:

```
  
  Configuration.Modules.AbpAutoMapper().Configurators.Add(CustomerPersonMapper.CreateMappings);
```

**配置权限功能**  : 

如果你生成了**权限功能**。复制以下代码到 PhoneBookApplicationModule.cs
中的 PreInitialize 方法中:

```
Configuration.Authorization.Providers.Add<PersonAppAuthorizationProvider>();
```

 **路线图**

todo: 目前优先完成SPA 以angular 为主，

如果你有想法我替你实现前端生成的代码块。
那么请到github 贴出你的代码段。
我感兴趣的话，会配合你的。

[https://github.com/52ABP/52ABP.CodeGenerator](https://github.com/52ABP/52ABP.CodeGenerator) 提供您的脑洞，

待办：
- [ ]SPA版本的前端
- [ ]配置多语言的地方
- [ ]暂时搞不定注释，后期想办法
- [ ]菜单栏问题，如果是MPA版本
- [ ]MPA版本的前端



*
 * 
 */
