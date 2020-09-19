<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
     xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html>
      <body>
        <h1>テストデータ(主観)</h1>

        <h2>book</h2>

        <ul>
          <xsl:for-each select="/books/good">
            <li>
              <xsl:value-of select="name" />は<xsl:value-of select="review" />
            </li>
          </xsl:for-each>
        </ul>

        <h2></h2>

        <ul>
          <xsl:for-each select="/books/bad">
            <li>
              <xsl:value-of select="name" />は<xsl:value-of select="review" />
            </li>
          </xsl:for-each>
        </ul>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>