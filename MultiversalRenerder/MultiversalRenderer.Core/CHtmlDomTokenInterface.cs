using System;

namespace MultiversalRenderer.Core
{
	/// <summary>
	/// CHtmlDomTokenInterface is DomTokenInterface
	/// interface DOMTokenList {
	/// readonly attribute unsigned long length;
	/// getter DOMString? item(unsigned long index);
	/// boolean contains(DOMString token);
	/// void add(DOMString... tokens);
	/// void remove(DOMString... tokens);
	/// boolean toggle(DOMString token, optional boolean force);
	/// stringifier;
    /// };
	/// </summary>
	public interface CHtmlDomTokenInterface
	{
		 bool contains(object tokens);
		 void add(object tokens);
		 void remove(object tokens);
		 bool toggle(string token,  bool force);
		 bool toggle(string token);
	}
}
