### 設定ファイル

|・[概要](#概要)<br>・[merino.json](#merino.json)<br>・[database.json](#database.json)|
|:-|

#### 概要
resource/templateフォルダにある設定ファイルをWebプロジェクトのconfigフォルダへコピー

<br><br>
<p id="merino.json">merino.json</p>
フレームワークに必要な設定を記載する

```json:merino.json
{
  "MerinoSettings": {
    "SettingFile": {
      "Database": "database.json"
    },
    "CustomSettingFile": [
      {
        "AssemblyName": "WebMvcSampleLibrary",
        "ClassName": "WebMvcSampleLibrary.Util.Test1SettingFile",
        "FileName": "test1.json"
      }
    ],
    "Env": 1,
    "EnvSetting": [
      {
        "EnvCls": 1,
        "EnvName": "local"
      },
      {
        "EnvCls": 2,
        "EnvName": "develop"
      },
      {
        "EnvCls": 3,
        "EnvName": "st"
      },
      {
        "EnvCls": 4,
        "EnvName": "prod"
      }
    ]
  }
}
```

|項目|内容|
| ---- | ---- |
| SettingFile | フレームワーク既定の設定ファイル名を記載|
|SettingFile.Database |データベース関連設定|
|SettingFile.CustomSettingFile |独自設定ファイル|
|Env |環境|
|EnvSetting |環境設定|


CustomSettingFile

|項目|内容|
| ---- | ---- |
|AssemblyName |アセンブリ名|
|ClassName |バインドするクラスの名前空間含めた名前|
|FileName |ファイル名|

EnvSetting

|項目|内容|
| ---- | ---- |
|EnvCls |環境区分|
|EnvName |環境名|


<br><br>
<p id="database.json">database.json</p>

```json:database.json
{
  "DatabaseSetting": {
    "DataSources": {
      "DataSource": [
        {
          "ConnectionString": "Server=(localdb)\\mssqllocaldb;Database=WebMvcSample.Data;Trusted_Connection=True;MultipleActiveResultSets=true",
          "EntityFramework": {
            "Valid": true,
            "UseDatabase": "SqlServer",
            "ContextAssemblyName": "WebMvcSampleLibrary",
            "ContextClassName": "WebMvcSampleLibrary.Data.WebMvcSampleContext"
          }
        },
        {
          "ConnectionString": "test",
          "EntityFramework": {
            "Valid": true,
            "UseDatabase": "PostgreSQL",
            "ContextAssemblyName": "WebMvcSampleLibrary",
            "ContextClassName": "WebMvcSampleLibrary.Data.WebMvcSampleContext"
          }
        }
      ]
    }
  }
}
```

|項目|内容|
| ---- | ---- |
| DataSource | |
|DataSources.ConnectionStrig|データベースへの接続文字列|