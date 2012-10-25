//	---------------------------------------------------------------------------
//	$Filename: D:\DotNet\TS\TS\ClassEncrypt.cs $
//	$Revision: 1.1 $
//
//	Core code downloaded from http://www.aspemporium.com/howto.aspx?hid=10
//	---------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

public class ClassEncrypt
{
	#region Declarations
	private string m_Password;
	#endregion

	public ClassEncrypt()
	{
		//	Define a default password. This can be overridden by
		//	the caller of this class.

		this.m_Password = "Frenzy";
	}

	public ClassEncrypt(string Password)
	{
		this.m_Password = Password;
	}

	public string Encrypt(string SrcStr, string Pwd)
	{
		string OldPwd = this.m_Password;
		string NewStr;

		this.m_Password = Pwd;

		NewStr = Encrypt(SrcStr);
		this.m_Password = OldPwd;

		return NewStr;
	}

	public string Encrypt(string SrcStr)
	{
		string encrypted;
		TripleDESCryptoServiceProvider des;
		MD5CryptoServiceProvider hashmd5;
		byte[] pwdhash, buff;

		//generate an MD5 hash from the m_Password. 
		//a hash is a one way encryption meaning once you generate
		//the hash, you cant derive the m_Password back from it.

		hashmd5 = new MD5CryptoServiceProvider();
		pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(m_Password));
		hashmd5 = null;

		//implement DES3 encryption

		des = new TripleDESCryptoServiceProvider();

		//the key is the secret m_Password hash.

		des.Key = pwdhash;

		//the mode is the block cipher mode which is basically the
		//details of how the encryption will work. There are several
		//kinds of ciphers available in DES3 and they all have benefits
		//and drawbacks. Here the Electronic Codebook cipher is used
		//which means that a given bit of text is always encrypted
		//exactly the same when the same m_Password is used.

		des.Mode = CipherMode.ECB; //CBC, CFB

		//----- encrypt an un-encrypted string ------------
		//the SrcStr string, which needs encrypted, must be in byte
		//array form to work with the des3 class. everything will because
		//most encryption works at the byte level so you'll find that
		//the class takes in byte arrays and returns byte arrays and
		//you'll be converting those arrays to strings.

		buff = ASCIIEncoding.ASCII.GetBytes(SrcStr);

		//encrypt the byte buffer representation of the SrcStr string
		//and base64 encode the encrypted string. the reason the encrypted
		//bytes are being base64 encoded as a string is the encryption will
		//have created some weird characters in there. Base64 encoding
		//provides a platform independent view of the encrypted string 
		//and can be sent as a plain text string to wherever.

		encrypted = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length));

		//cleanup

		des = null;

		return encrypted;
	}

	public string Decrypt(string SrcStr, string Pwd)
	{
		string OldPwd = this.m_Password;
		string NewStr;

		this.m_Password = Pwd;
		NewStr = Decrypt(SrcStr);
		this.m_Password = OldPwd;

		return NewStr;
	}

	public string Decrypt(string SrcStr)
	{
		string decrypted;
		TripleDESCryptoServiceProvider des;
		MD5CryptoServiceProvider hashmd5;
		byte[] pwdhash, buff;

		//generate an MD5 hash from the m_Password. 
		//a hash is a one way encryption meaning once you generate
		//the hash, you cant derive the m_Password back from it.

		hashmd5 = new MD5CryptoServiceProvider();
		pwdhash = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(m_Password));
		hashmd5 = null;

		//implement DES3 encryption

		des = new TripleDESCryptoServiceProvider();

		//the key is the secret m_Password hash.

		des.Key = pwdhash;

		//the mode is the block cipher mode which is basically the
		//details of how the encryption will work. There are several
		//kinds of ciphers available in DES3 and they all have benefits
		//and drawbacks. Here the Electronic Codebook cipher is used
		//which means that a given bit of text is always encrypted
		//exactly the same when the same m_Password is used.

		des.Mode = CipherMode.ECB; //CBC, CFB

		//----- encrypt an un-encrypted string ------------
		//the SrcStr string, which needs encrypted, must be in byte
		//array form to work with the des3 class. everything will because
		//most encryption works at the byte level so you'll find that
		//the class takes in byte arrays and returns byte arrays and
		//you'll be converting those arrays to strings.

		buff = ASCIIEncoding.ASCII.GetBytes(SrcStr);

		//----- decrypt an encrypted string ------------
		//whenever you decrypt a string, you must do everything you
		//did to encrypt the string, but in reverse order. To encrypt,
		//first a normal string was des3 encrypted into a byte array
		//and then base64 encoded for reliable transmission. So, to 
		//decrypt this string, first the base64 encoded string must be 
		//decoded so that just the encrypted byte array remains.

		buff = Convert.FromBase64String(SrcStr);

		//decrypt DES 3 encrypted byte buffer and return ASCII string

		decrypted = ASCIIEncoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length));

		//cleanup

		des = null;

		return decrypted;
	}

	#region Properties
	public string Password
	{
		get
		{
			return m_Password;
		}
		set
		{
			m_Password = value;
		}
	}
	#endregion
}
