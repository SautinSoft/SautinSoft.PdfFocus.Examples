'A VB.NET wrapper class for NSOCR

'******************************************************************************
'                        Nicomsoft OCR DLL interface
'                    Copyright (c) 2010-2016 Nicomsoft
'                 Copyright (c) 2010-2016 Michael Kapustin
'                           www.nsocr.com
'******************************************************************************


Public Class TNSOCR

    'error codes
    Public Const ERROR_FIRST = &H70000000
    Public Const ERROR_FILENOTFOUND = &H70000001
    Public Const ERROR_LOADFILE = &H70000002
    Public Const ERROR_SAVEFILE = &H70000003
    Public Const ERROR_MISSEDIMGLOADER = &H70000004
    Public Const ERROR_OPTIONNOTFOUND = &H70000005
    Public Const ERROR_NOBLOCKS = &H70000006
    Public Const ERROR_BLOCKNOTFOUND = &H70000007
    Public Const ERROR_INVALIDINDEX = &H70000008
    Public Const ERROR_INVALIDPARAMETER = &H70000009
    Public Const ERROR_FAILED = &H7000000A
    Public Const ERROR_INVALIDBLOCKTYPE = &H7000000B
    Public Const ERROR_EMPTYTEXT = &H7000000D
    Public Const ERROR_LOADINGDICTIONARY = &H7000000E
    Public Const ERROR_LOADCHARBASE = &H7000000F
    Public Const ERROR_NOMEMORY = &H70000010
    Public Const ERROR_CANNOTLOADGS = &H70000011
    Public Const ERROR_CANNOTPROCESSPDF = &H70000012
    Public Const ERROR_NOIMAGE = &H70000013
    Public Const ERROR_MISSEDSTEP = &H70000014
    Public Const ERROR_OUTOFIMAGE = &H70000015
    Public Const ERROR_EXCEPTION = &H70000016
    Public Const ERROR_NOTALLOWED = &H70000017
    Public Const ERROR_NODEFAULTDEVICE = &H70000018
    Public Const ERROR_NOTAPPLICABLE = &H70000019
    Public Const ERROR_MISSEDBARCODEDLL = &H7000001A
    Public Const ERROR_PENDING = &H7000001B
    Public Const ERROR_OPERATIONCANCELLED = &H7000001C
    Public Const ERROR_TOOMANYLANGUAGES = &H7000001D
    Public Const ERROR_OPERATIONTIMEOUT = &H7000001E
    Public Const ERROR_LOAD_ASIAN_MODULE= &H7000001F	
    Public Const ERROR_LOAD_ASIAN_LANG	= &H70000020
    Public Const ERROR_INVALIDOBJECT = &H70010000
    Public Const ERROR_TOOMANYOBJECTS = &H70010001
    Public Const ERROR_DLLNOTLOADED = &H70010002
    Public Const ERROR_DEMO = &H70010003

    'block types
    Public Const BT_DEFAULT = 0
    Public Const BT_OCRTEXT = 1
    Public Const BT_ICRDIGIT = 2
    Public Const BT_CLEAR = 3
    Public Const BT_PICTURE = 4
    Public Const BT_ZONING = 5
    Public Const BT_OCRDIGIT = 6
    Public Const BT_BARCODE = 7
    Public Const BT_TABLE = 8
    Public Const BT_MRZ = 9

    'Constants for Img_LoadBmpData function
    Public Const BMP_24BIT = &H0
    Public Const BMP_8BIT = &H1
    Public Const BMP_1BIT = &H2
    Public Const BMP_32BIT = &H3
    Public Const BMP_BOTTOMTOP = &H100

    'Constants for Img_GetImgText, Blk_GetText and Svr_AddPage functions
    Public Const FMT_EDITCOPY = &H0
    Public Const FMT_EXACTCOPY = &H1

    'for Img_OCR
    Public Const OCRSTEP_FIRST = &H0 'first step
    Public Const OCRSTEP_PREFILTERS = &H10 'filters before binarizing: scaling, invert, rotate etc
    Public Const OCRSTEP_BINARIZE = &H20 'binarize
    Public Const OCRSTEP_POSTFILTERS = &H50 'bin garbage filter etc
    Public Const OCRSTEP_REMOVELINES = &H60 'find and remove lines
    Public Const OCRSTEP_ZONING = &H70 'analyze page layout
    Public Const OCRSTEP_OCR = &H80 'ocr itself
    Public Const OCRSTEP_LAST = &HFF 'last step

    'for Img_OCR, "Flags" parameter
    Public Const OCRFLAG_NONE = &H0 'default mode (blocking)
    Public Const OCRFLAG_THREAD = &H1 'non-blocking mode
    Public Const OCRFLAG_GETRESULT = &H2 'get result for non-blocking mode
    Public Const OCRFLAG_GETPROGRESS = &H3 'get progress
    Public Const OCRFLAG_CANCEL = &H4 'cancel ocr

    'for Img_DrawToDC and Img_GetBmpData
    Public Const DRAW_NORMAL = &H0
    Public Const DRAW_BINARY = &H1
    Public Const DRAW_GETBPP = &H100

    'values for Blk_Inversion function
    Public Const BLK_INVERSE_GET = -1
    Public Const BLK_INVERSE_SET0 = 0
    Public Const BLK_INVERSE_SET1 = 1
    Public Const BLK_INVERSE_DETECT = &H100

    'for Blk_Rotation function
    Public Const BLK_ROTATE_GET = -1
    Public Const BLK_ROTATE_NONE = 0
    Public Const BLK_ROTATE_90 = &H1
    Public Const BLK_ROTATE_180 = &H2
    Public Const BLK_ROTATE_270 = &H3
    Public Const BLK_ROTATE_ANGLE = &H100000
    Public Const BLK_ROTATE_DETECT = &H100

    'for Blk_Mirror function
    Public Const BLK_MIRROR_GET = -1
    Public Const BLK_MIRROR_H = &H1
    Public Const BLK_MIRROR_V = &H2

    'for Svr_Create function   
    Public Const SVR_FORMAT_PDF = &H1
    Public Const SVR_FORMAT_RTF = &H2
    Public Const SVR_FORMAT_TXT_ASCII = &H3
    Public Const SVR_FORMAT_TXT_UNICODE = &H4
    Public Const SVR_FORMAT_XML = &H5
    Public Const SVR_FORMAT_PDFA = &H6

    'for Scan_Enumerate function
    Public Const SCAN_GETDEFAULTDEVICE = &H1
    Public Const SCAN_SETDEFAULTDEVICE = &H100

    'for Scan_ScanToImg and Scan_ScanToFile functions
    Public Const SCAN_NOUI = &H1
    Public Const SCAN_SOURCEADF = &H2
    Public Const SCAN_SOURCEAUTO = &H4
    Public Const SCAN_DONTCLOSEDS = &H8
    Public Const SCAN_FILE_SEPARATE = &H10

    'for Blk_GetWordFontStyle function
    Public Const FONT_STYLE_UNDERLINED = &H1
    Public Const FONT_STYLE_STRIKED = &H2
    Public Const FONT_STYLE_BOLD = &H4
    Public Const FONT_STYLE_ITALIC = &H8

    'for Img_GetProperty function, PropertyID parameter
    Public Const IMG_PROP_DPIX = &H1   'original DPI
    Public Const IMG_PROP_DPIY = &H2
    Public Const IMG_PROP_BPP = &H3   'color depth
    Public Const IMG_PROP_WIDTH = &H4   'original width
    Public Const IMG_PROP_HEIGHT = &H5   'original height
    Public Const IMG_PROP_INVERTED = &H6    'image was inverted
    Public Const IMG_PROP_SKEW = &H7   'image skew angle after OCR_STEP_PREFILTERS step, multiplied by 1000
    Public Const IMG_PROP_SCALE = &H8   'image scale factor after OCR_STEP_PREFILTERS step, multiplied by 1000
    Public Const IMG_PROP_PAGEINDEX = &H9 'image page index

    'for "Blk_SetWordRegEx" function
    Public Const REGEX_SET = &H0
    Public Const REGEX_CLEAR = &H1
    Public Const REGEX_CLEAR_ALL = &H2
    Public Const REGEX_DISABLE_DICT = &H4
    Public Const REGEX_CHECK = &H8

    'for Svr_SetDocumentInfo function
    Public Const INFO_PDF_AUTHOR = &H1
    Public Const INFO_PDF_CREATOR = &H2
    Public Const INFO_PDF_PRODUCER = &H3
    Public Const INFO_PDF_TITLE = &H4
    Public Const INFO_PDF_SUBJECT = &H5
    Public Const INFO_PDF_KEYWORDS = &H6

    'for Blk_GetBarcodeType function
    Public Const BARCODE_TYPE_EAN8 = &H1
    Public Const BARCODE_TYPE_UPCE = &H2
    Public Const BARCODE_TYPE_ISBN10 = &H3
    Public Const BARCODE_TYPE_UPCA = &H4
    Public Const BARCODE_TYPE_EAN13 = &H5
    Public Const BARCODE_TYPE_ISBN13 = &H6
    Public Const BARCODE_TYPE_ZBAR_I25 = &H7
    Public Const BARCODE_TYPE_CODE39 = &H8
    Public Const BARCODE_TYPE_QRCODE = &H9
    Public Const BARCODE_TYPE_CODE128 = &HA

    'for "BarCode/TypesMask" configuration option
    Public Const BARCODE_TYPE_MASK_EAN8 = &H1
    Public Const BARCODE_TYPE_MASK_UPCE = &H2
    Public Const BARCODE_TYPE_MASK_ISBN10 = &H4
    Public Const BARCODE_TYPE_MASK_UPCA = &H8
    Public Const BARCODE_TYPE_MASK_EAN13 = &H10
    Public Const BARCODE_TYPE_MASK_ISBN13 = &H20
    Public Const BARCODE_TYPE_MASK_ZBAR_I25 = &H40
    Public Const BARCODE_TYPE_MASK_CODE39 = &H80
    Public Const BARCODE_TYPE_MASK_QRCODE = &H100
    Public Const BARCODE_TYPE_MASK_CODE128 = &H200

    'for Img_SaveToFile function
    Public Const IMG_FORMAT_BMP = 0
    Public Const IMG_FORMAT_JPEG = 2
    Public Const IMG_FORMAT_PNG = 13
    Public Const IMG_FORMAT_TIFF = 18
    Public Const IMG_FORMAT_FLAG_BINARIZED = &H100
End Class