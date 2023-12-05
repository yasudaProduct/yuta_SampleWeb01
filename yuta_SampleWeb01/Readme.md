

トランザクションなしの場合
_context.TUser.Add(user);
_context.SaveChanges() //コミットされない

トランザクションありの場合
using (var tran = _context.Database.BeginTransaction())
{
	_context.TUser.Add(user);
	_context.SaveChanges()　//コミットされない

	tran.Commit() //コミットされる

}
