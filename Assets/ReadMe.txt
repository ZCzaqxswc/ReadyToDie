//------------------------------
// ���� ����
//------------------------------

[�����ּ�]
222.112.183.217:3888


[������ �α�������ġ]
C:\SLIMELOG\LOG2021-2-1-15.txt

//------------------------------
// TCP�������� �����ؼ� ������
//------------------------------
stHeader header;
      header.iID = prZIP;
      header.Type.iDeCompressLen = size;
      header.iLength = zipsize;
      header.iCheckSum = header.Type.iType + header.iLength + header.iID;


//------------------------------
// Ŭ�󿡼�  TCP����Ȱ� Ǯ��
//------------------------------
      if( header.iID == prZIP )
lzf_decompress( &m_RecvBuffer[ HEADSIZE ], header.iLength, ZipBuffer, header.Type.iDeCompressLen );


//------------------------------
// �������� �����ؼ� ������
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

        Buffer.BlockCopy( UnZiplen, 0, Packet, 0, 4 );  //������Ŷ��� ������� ������
        Buffer.BlockCopy( zlen, 0, Packet, 4, 4 );      //������Ŷ��� ������ ������
        Buffer.BlockCopy( Out, 0, Packet, 8, ziplen );  //����� ��Ŷ ����



//------------------------------
// Ŭ�󿡼� ����Ȱ� Ǯ��
//------------------------------

   //���� Ǭ������
   int UnZipSize = 0;
   memcpy( &UnZipSize, packet, sizeof( int ) );

   //�޸� �Ѿ��
   int nCn = sizeof( int );

   //�����ѻ�����
   int ZipSize = 0;
   memcpy( &ZipSize, &packet[ nCn ], sizeof( int ) );
   nCn += sizeof( int );    

   char* OutData = new char[ UnZipSize + 1 ];   
   memset( OutData, 0x00,  UnZipSize + 1 );

   int nNewZipSize = lzf_decompress( &packet[ nCn ], ZipSize, OutData, UnZipSize );




// ����Ʈ �迭�� String���� ��ȯ 
private string ByteToString(byte[] strByte) 
{ 
	string str = Encoding.Default.GetString(StrByte); 
	return str; 
} 

// String�� ����Ʈ �迭�� ��ȯ 
private byte[] StringToByte(string str) 
{
 	byte[] StrByte = Encoding.UTF8.GetBytes(str); 
	return StrByte; 
}

