

ASP.NET Core MVCアプリケーション

- ルーティング
- ログ
- 例外処理
- テスト
- デプロイ

### EntityFramework DbContext トランザクション
- トランザクションなしの場合

```
_context.TUser.Add(user);
_context.SaveChanges() //コミットされない
```

- トランザクションありの場合
```
using (var tran = _context.Database.BeginTransaction())
{
	_context.TUser.Add(user);
	_context.SaveChanges()　//コミットされない

	tran.Commit() //コミットされる

}
```


### フォルダ構成

## DDD
- config
- Const
- Controllers
- Data
- Migrations
- Models
- Services
- ViewModels
- Views
- appsettings.json
- nlog.config
- Program.cs