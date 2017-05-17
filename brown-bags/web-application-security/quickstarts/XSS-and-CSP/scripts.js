function XSS()
{
    var data = "<script>alert('Hello World!');<\/script>";
    var data = escape(data);
    document.write(data);
}