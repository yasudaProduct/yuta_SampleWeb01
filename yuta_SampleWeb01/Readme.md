
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

### EntityFramework マイグレーション
```
// データベースを削除する
dotnet ef database drop -f -v

// マイグレーションをやり直す
dotnet ef migrations add Initial

// DBを更新する
dotnet ef database update
```

### フォルダ構成
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