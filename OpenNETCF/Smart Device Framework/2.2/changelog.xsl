<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="2.0"
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

	<xsl:template match="changelog">
		<html>
			<head>
				<meta http-equiv="Content-type" content="text/html; charset=utf-8"/>
				<title>Smart Device Framework 2.2 SP1 Changelog</title>
				<style type="text/css" media="all">
				<![CDATA[
					body {						
						font-family: Tahoma;
						font-size: 0.8em;
						margin: 0;
						padding: 0;
					}
					
					a, a:active, a:visited {
						color: #000;
					}	
					
					#report {
						margin-left: 10px;
						margin-top: 10px;
						width: 600px;
					}
					
					#drop-date {
						font-size: 12px;
						font-weight: normal;
					}
					
					#status {
						padding-right: 5px;
					}
					
					#cr {
						margin-top: 20px;
						font-size: 10px;
					}
					
					div#bugs {
						border-top: 1px solid #bbb;
					}
					
					div.bug {
						padding: 5px;
						border-bottom: 1px solid #bbb;
						border-top: 0;
					}
				]]>
				</style>			
			</head>
			<body>
				<div id="report">					
					<h1>Smart Device Framework 2.2 SP1
					<div id="drop-date"><xsl:apply-templates select="releasedate"/></div></h1>
					<p style="text-align: justify">
						Below is a summary of the fixes and changes contained within Smart Device Framework 2.2 Service Pack 1. 
						These bugs were reported by valued customers and OpenNETCF team members following the release of Smart 
						Device Framework 2.2 on February 14, 2008. 
					</p> 
					<p>
						Click the Bug ID to see the full details in our online <a href="http://bugzilla.opennetcf.com/" target="_new">bug tracker</a>.
					</p>
					<div style="width: 600px; margin-top: 10px;">	
						<h3>Bug Fixes</h3>
						<div id="bugs">										
							<xsl:apply-templates select="bugs"/>
						</div>
					</div>
					<p id="cr">Copyright (c) 2008 OpenNETCF Consulting, LLC.</p>
				</div>
			</body>
		</html>
	</xsl:template>
	
	<xsl:template match="bug">
			<div class="bug"><xsl:attribute name="name"><xsl:value-of select="@sev"/></xsl:attribute>
				<a>
					<xsl:attribute name="href">http://bugzilla.opennetcf.com/show_bug.cgi?id=<xsl:value-of select="@id"/></xsl:attribute>
					<xsl:attribute name="target">_new</xsl:attribute>#<xsl:value-of select="@id"/>
				</a>: <xsl:value-of select="@title"/>
			</div>
	</xsl:template>
	
	<xsl:template match="releasedate">
		Release Date: <xsl:value-of select="." />
	</xsl:template>

</xsl:stylesheet>