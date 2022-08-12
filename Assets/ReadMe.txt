//------------------------------
// 각종 정보
//------------------------------

[서버주소]
222.112.183.217:3888


[웹서버 로그파일위치]
C:\SLIMELOG\LOG2021-2-1-15.txt

//------------------------------
// TCP서버에서 압축해서 보낼때
//------------------------------
stHeader header;
      header.iID = prZIP;
      header.Type.iDeCompressLen = size;
      header.iLength = zipsize;
      header.iCheckSum = header.Type.iType + header.iLength + header.iID;


//------------------------------
// 클라에서  TCP압축된거 풀때
//------------------------------
      if( header.iID == prZIP )
lzf_decompress( &m_RecvBuffer[ HEADSIZE ], header.iLength, ZipBuffer, header.Type.iDeCompressLen );


//------------------------------
// 서버에서 압축해서 보내기
//------------------------------
   String JsonString;
        JsonObjectCollection json = new JsonObjectCollection();
        json.Add( new JsonStringValue( "protocol", Convert.ToString( protocol ) ) );
        json.Add( new JsonStringValue( "result", str ) );
        JsonString = json.ToString();


        Int32[] UnZiplen = new int[1];

        Int32[] zlen = new int[1];
        int ziplen = 0;

        byte[] bStrByteA = Encoding.UTF8.GetBytes( JsonString );   // string -> byte
        byte[] Out = lzf.ZIP(bStrByteA, ref ziplen);

        UnZiplen[0] = bStrByteA.Length;
        zlen[0] = ziplen;

        int PaketSize = ziplen + 8;
        byte[] Packet = new byte[ PaketSize ];

        Buffer.BlockCopy( UnZiplen, 0, Packet, 0, 4 );  //압축패킷헤더 압축안한 사이즈
        Buffer.BlockCopy( zlen, 0, Packet, 4, 4 );      //압축패킷헤더 압축한 사이즈
        Buffer.BlockCopy( Out, 0, Packet, 8, ziplen );  //압축된 패킷 몸통



//------------------------------
// 클라에서 압축된거 풀기
//------------------------------

   //압축 푼사이즈
   int UnZipSize = 0;
   memcpy( &UnZipSize, packet, sizeof( int ) );

   //메모리 넘어갈값
   int nCn = sizeof( int );

   //압축한사이즈
   int ZipSize = 0;
   memcpy( &ZipSize, &packet[ nCn ], sizeof( int ) );
   nCn += sizeof( int );    

   char* OutData = new char[ UnZipSize + 1 ];   
   memset( OutData, 0x00,  UnZipSize + 1 );

   int nNewZipSize = lzf_decompress( &packet[ nCn ], ZipSize, OutData, UnZipSize );




// 바이트 배열을 String으로 변환 
private string ByteToString(byte[] strByte) 
{ 
	string str = Encoding.Default.GetString(StrByte); 
	return str; 
} 

// String을 바이트 배열로 변환 
private byte[] StringToByte(string str) 
{
 	byte[] StrByte = Encoding.UTF8.GetBytes(str); 
	return StrByte; 
}

