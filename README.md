# CIUACHelper
Classisland插件，启动时自动提权
- [StartUpAsAdmin](https://github.com/ClassIsland/StartUpAsAdmin) 替代品，相比它本插件有更多优点，详见下。
-  安装后，你可以忽视[GrantUiAccess](https://github.com/HelloWRC/GrantUiAccess) 中的第二条使用说明
-  一定程度上修复了管理员权限无法自启的bug

## 已知问题
- 会导致启动速度减慢几毫秒
- 会使原本的程序运行参数丢失
解决方案∶合并入classisland本体

## 优点
- 开箱即用，无需修改classisland.exe的兼容性设置（相比GrantUiAccess）
- 绿色无痕，不依赖计划任务或服务，卸载只需一键（相比StartUpAsAdmin）
- 小巧极简，40kb大小遥遥领先
- 毫无依赖，除了ci插件api外再无第三方库（相比StartUpAsAdmin）
- 沉浸体验，无需改变你的ci使用习惯，支持原生自启动（相比其他插件）

## 注意
- 本插件不是GrantUiAccess的替代品
