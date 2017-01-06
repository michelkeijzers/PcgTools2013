<?php
if(!file_exists('Counters/counter_installer.txt')){
  file_put_contents('Counters/counter_installer.txt', '0');
}
if($_GET['click_installer'] == 'yes'){
  file_put_contents('Counters/counter_installer.txt', ((int) file_get_contents('Counters/counter_installer.txt')) + 1);
  header('Location: ' . 'http://pcgtools.mkspace.nl/Releases/PcgTools2.5.1.exe');
  die;
}

if(!file_exists('Counters/counter_manual.txt')){
  file_put_contents('Counters/counter_manual.txt', '0');
}
if($_GET['click_manual'] == 'yes'){
  file_put_contents('Counters/counter_manual.txt', ((int) file_get_contents('Counters/counter_manual.txt')) + 1);
  header('Location: ' . 'http://pcgtools.mkspace.nl/Releases/Manual.pdf');
  die;
}
?>

<!DOCTYPE html>

<html lang="en" xmlns="http://www.w3.org/1999/xhtml">
  <head>
    <title>PCG Tools: Download</title>
    <meta charset="utf-8" name="keywords" content="PCG Tools, korg, synthesizer, synthesizers, workstation, workstations, librarian, editor, music, PCG files, PCG, files, patch, patches, program, programs, combi, combis, global, cubase, sng, set lists, set list, set list slots, kronos x, kronos, oasys, krome, kross, m3, m50, triton extreme, triton studio, triton classic, triton le, triton, triton rack, triton tr, karma, trinity v1, trinity v2, trinity v3, trinity tr rack, m1, m3r, 01w, z1, t1, t2, t3">
    <meta name="description" content="A free software application for Korg synthesizers/workstations, download">

    <link rel="shortcut icon" href="http://pcgtools.mkspace.nl/favicon.ico">

    <script>
     (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
     (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
     m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
     })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

     ga('create', 'UA-46096075-1', 'mkspace.nl');
     ga('send', 'pageview');
    </script>

    <style>
     @import url('style.css');
    </style>
  </head>

  <body>
<style>
table, th, td
{
border-collapse:collapse;
border:1px solid black;
}
th, td
{
padding:5px;
}
</style>

      <img src="http://pcgtools.mkspace.nl/pcgtoolsnormal.jpg" alt=""/>

    <div id="menu">
      <ul>
        <li><a href="http://pcgtools.mkspace.nl/index.html" title="Home">Home</a></li>
        <li><a href="http://pcgtools.mkspace.nl/whoami.html" title="Who Am I?">Who Am I?</a></li>
        <li><a href="http://pcgtools.mkspace.nl/support.html" title="Support">Support</a></li>
        <li><a href="http://pcgtools.mkspace.nl/download.php" title="Download">Download</a></li>
        <li><a href="http://pcgtools.mkspace.nl/history.html">History</a></li>
        <li><a href="http://pcgtools.mkspace.nl/wishlist.html">Wish List</a></li>
        <li><a href="http://pcgtools.mkspace.nl/known_issues.html">Issues</a></li>
        <li><a href="http://pcgtools.mkspace.nl/contact.html" title="Contact">Contact</a></li>
        <li><a href="http://pcgtools.mkspace.nl/faq.html" title="Links">FAQ</a></li>
        <li><a href="http://pcgtools.mkspace.nl/links.html" title="Links">Links</a></li>
    </ul>
  </div>

  <h1>Download</h1>
    <p>
        PCG Tools is a Windows application. To use it on an Apple (c) or Unix computer, see the manual for more info (using a Windows emulator).</p>
     </p>

        <h2>Windows Installer</h2>
           Windows requirements: Windows XP SP3, Windows Vista, Windows 7, Windows 8
           <h3><a href="?click_installer=yes">Releases\PCG Tools 2.5.1 Installer (.exe)</a></h3>
           <h5>PCG Tools has been downloaded <?php echo file_get_contents('Counters/counter_installer.txt'); ?> times</h5>
           <h5>It is forbidden to host this application on other websites without permission from the developer.</h5>

        <h4>NOTICE: When you download this free application and after you think it is useful, think about a donation.</h4>
<form action="https://www.paypal.com/cgi-bin/webscr" method="post" target="_top">
<input type="hidden" name="cmd" value="_s-xclick">
<input type="hidden" name="encrypted" value="-----BEGIN PKCS7-----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-----END PKCS7-----
">
<input type="image" src="https://www.paypalobjects.com/nl_NL/NL/i/btn/btn_donateCC_LG.gif" border="0" name="submit" alt="PayPal, de veilige en complete manier van online betalen.">
<img alt="" border="0" src="https://www.paypalobjects.com/nl_NL/i/scr/pixel.gif" width="1" height="1">
</form>


        Also, go to the Contact tab and check FaceBook, Twitter, Google or KorgForums to get into contact with other users of PCG Tools.

        <h2>Virtual Banks</h2>
         PCG Tools can use files with virtual banks to store a lot of programs/combis. Below you can download them for your own use.
        <h4><a href="Files/Kronos_Preload_VB.zip">Kronos Preload Virtual Banks PCG File</a></h4>
         This file contains the (zipped) default Preload data for the Korg Kronos (X) with 64 extra empty program and combi banks (of 128 patches each).
        <h4><a href="Files/MS2000_Empty.zip">MS2000_MS2000 Empty Virtual Banks LIB file</a></h4>
         This file contains a (zipped) LIB file for the Korg MS2000 with 64 extra empty program banks (of 16 programs each).

        <h2>Other Files</h2>
         <h4><a href="Files/KronosV2V3Rules.txt">KronosV2V3Rules.txt</a></h4>
         This file contains the rules to be imported in the Program Reference changer in the Tools menu of PCG Tools.
        The rules can be used to use V2 (or earlier) Kronos combis and set list PCG files with a V3 programs layout.
        If you see this file as text in your browser, copy the contents in a file name and import the file in PCG Tools in the Program Reference Changer.
         For now, after loading, compress the Rules text box to press the OK button ... it can take about 10 minutes to process all rules (in the next version it will be much faster).

        <h2>Update notifications</h2>
          You can receive automatic update or important email notifications by subscribing to the PCG Tools Yahoo group.
          <h3><a href="http://groups.yahoo.com/neo/groups/pcgtools/info">Join the Yahoo PCG Tools group</a></h3>

        <h2>Manual</h2>
          Please read the manual before asking questions. It's very extensive, but well structured. Also, a lot of examples can be found.
           <h3><a href="?click_manual=yes">PCG Tools Manual</a></h3>
           <h5>PCG Tools Manual has been downloaded <?php echo file_get_contents('Counters/counter_manual.txt'); ?> times</h5>

           <h3><a  href="NewCutCopyPasteSettings.pdf">More info about new Cut/Copy/Paste Settings</a></h3>

      <h2>Release Notes Version 2.5.1</h2>
       <table border="1">
         <tr><td>Bug Fix</td><td>Prevented crash for set list generator for non Kronos PCG files.</td></tr>
       </table>

      <h2>Release Notes Version 2.5.0</h2>
       <table border="1">
         <tr><td>Feature</td><td>Program reference changer (to change references in combis/set lists to programs).</td></tr>
         <tr><td>Improvement</td><td>Possibility to treat equal/like-named patches as duplicates while copy/pasting.</td></tr>
         <tr><td>Improvement</td><td>For Kronos set list slot editor: Added color/transpose controls.</td></tr>
         <tr><td>Improvement</td><td>For Kronos set list slot editor: Fixed XS/S mismatch for font size.</td></tr>
         <tr><td>Bug Fix</td><td>Fixed copy/pasting set list slots (Kronos only).</td></tr>
         <tr><td>Bug Fix</td><td>Fixed double clicking a PCG file to start up PCG Tools.</td></tr>
         <tr><td>Bug Fix</td><td>Prevented crash when loading Kronos files with set lists, without combis.</td></tr>
         <tr><td>Language</td><td>Italian language added, thanks to Enrico Puglisi.</td></tr>
         <tr><td>Language</td><td>Many greek texts improved, thanks to Giorgios (new translator) and Jim Dijkstra.</td></tr>
         <tr><td>Language</td><td>Corrected/translated (missing) language texts (thanks to various translators).</td></tr>
         <tr><td>Links</td><td>Completely redesigned all external links windows.</td></tr>
         <tr><td>Links</td><td>Added contributors window, for thanking testers, information/idea providers etc.</td></tr>
         <tr><td>Links</td><td>Added Timo Lill, as translator for German (amongst others) and added various URLs.</td></tr>
         <tr><td>Donators</td><td>Added  Kevin Nolan and various URLs of donators.</td></tr>
       </table>

       <h2>Bug reports</h2>
          <p>If you find a bug, make sure you use the latest version. If you can stills ee the bug, please send a mail to me: <a href="mailto:michelkeijzers@hotmail.com">Bug report</a><p>
          <p>Please provide the following info:</p>
               <ul>
                  <li>Description of the bug.</li>
                  <li>Operating system and relevant computer system information.</li>
                  <li>Attach a screenshot if needed.</li>
                  <li>Attach the PCG file resulting in the problem (I will never share PCG files received this way with others).</li>
                  <li>Describe exactly how to reproduce the problem.</li>
               </ul>
              Thanks in advance for taking the trouble; without bug reports I will probably never know of all bugs, since I don't own all Korg workstation/synths supported by PCG Tools.

         <h2>Source code</h3>
             The code is written in C#. For now I don't send the source code, due to the fact it could be used for commercial reasons by others. All code is copyright protected.
             None of my code is allowed to be used in commercial software, but can be requested for non commercial usage.
             When I see good/serious reasons why someone would use the code I will think about it (like serious plans to do some conversion, nice addition or porting to another platform).

            <h2>Disclaimer</h2>
             I am not responsible for corrupt PCGs. Therefore, always make a backup first and test regularly. I do not own all models so testing has been very limited.
             I am not responsible for the content of the PCGs being used with the application.

            <h2>Copyright</h2>
             PCG Tools is a free application, however the executable and the source code may never be used for commercial reasons.
             Also the application may not be spread except by the developer. It may not be uploaded to web sites, peer to peer networks, spread by email or by other means without permission of the developer.

             The reason for this, is that the developer maintains a list of people who are using PCG Tools and when a new update is available, it will be send to everybody on this update list, to make sure everybody always receives the latest version.

             This application is not affiliated by Korg, so requests, bugs, wishes, questions etc. should be directed to michel.keijzers@hotmail or being posted on the main PCG Tools thread (this thread).
    </body>
</html>
