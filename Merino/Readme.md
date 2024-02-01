# Merino

新規Webソリューション作成方法

dllを参照に追加
Program.csを修正
Configフォルダを作成し、templateフォルダ内にある設定ファイルをコピー

## Webアプリケーションの初期化

1. [設定ファイル](/Document/Setting.md)の準備

2. WEBプロジェクトの参照に追加
3. Program.csを修正

```C#:Program.cs
using Merino;

//アプリケーション初期化
WebApplicationBuilder builder = BootStrap.BuildWebApplication(args);

WebApplication app = BootStrap.CreateWebApplication(builder);

BootStrap.RunWebApplication(app);

```

## 依存注入


## ログ

## Entity Framework

#### ・マイグレーションの実行

```
// マイグレーションファイル作成
dotnet ef migrations add [マイグレーションファイル名] --project [Contextを含むプロジェクト] --startup-project [実行プロジェクト] --context [実行するContext]

// DBを更新する
dotnet ef database update --context [実行するContext]

// データベースを削除する
dotnet ef database drop -f -v --context [実行するContext]
```

```
>dotnet ef migrations add Initial --project ..\WebMvcSampleLibrary\WebMvcSampleLibrary.csproj --startup-project .\WebMvcSample.csproj --context PostgresContext
Build started...
Build succeeded.
Done. To undo this action, use 'ef migrations remove'

>dotnet ef database update --context PostgresContext
Build started...
Build succeeded.
Applying migration '20240119070959_Initial'.
Done.
```

## 例外

## メッセージ

## セッション管理

## キャッシュ管理

## 利用ライブラリ