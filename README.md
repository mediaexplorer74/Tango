# Tango 1.0.100 pre-alpha

![](/Images/logo.png)

My fast & dirty R.E. of Tango for WP7 app and making UWP app for Windows 10 Mobile... 


## Functional features
- Min. Win SDK used: 15063

## Status
- INIT STATE: The project is in a very early stage and not yet available for distribution.
- +- Pre-Aplha (100500 bugs still here!!! )
- Little WIKI created. You can find it here: https://github.com/mediaexplorer74/Tango/wiki

## Screenshots
![](/Images/sshot01.png)
![](/Images/sshot01.png)


## Design
![](/Design/Tango_1.png)
![](/Design/Tango_2.png)

## Project Structure 

1. Main Application: 

WinPhoneTango - The UWP application project

2. Core Components:
- Tango.Drivers - Contains driver interfaces and implementations
- Tango.Messages - Likely contains message definitions
- Google.ProtocolBuffers - Protocol Buffers implementation
- Image processing libraries (ImageTools and various codecs)



## Tech. details
- App type: UWP
- Win. SDK used: 19041
- Min. Win SDK used: 15063

Key tech. notes :

1. XMPP Implementation: The XMPP client implementation appears to be incomplete or stubbed out. The actual communication seems to happen through COM components:
- WPTangoEngine - Main engine component
- WPMessageSender - Message sending component

2. Communication Pattern:
- Messages are sent via COM interfaces using Protocol Buffers
- The actual XMPP connection and protocol handling is likely implemented in native code within the EngineCOM.dll
- The C# code acts as a wrapper/bridge to the native implementation

Missing Components:
- No actual .proto files defining the message formats
- The XMPP client implementation is minimal/stubbed
- The EngineCOM.dll native library is missing

## TODO

Common plan: 
- Try to partially disassemble (see _C_  folder) this important dll-s: EngineCOM.dll, SecProxyClient.dll, ComRegRw_Tango.dll
- Try to find some "sgiggle.xmpp" (idk what is it... xmpp protocol handler?)
- Explore additional info about original "Tango" messengers (history, targets, platforms, state, etc.)

Detail plan:
- Analyze existing XMPP stubs and identify missing functionality
- Research Tango.me protocol or create a compatible XMPP-based protocol
- Implement a pure C# XMPP client for UWP
- Create Protocol Buffer message definitions based on existing stubs
- Replace COM dependencies with pure C# implementations
- Update driver implementations for UWP compatibility
- Test the implementation and create documentation


## Recommendations for Porting to UWP
Since you want to port this to UWP and potentially connect to a Tango server or create your own, here's what I recommend:

1. Create a Modern XMPP Client: Since the original COM-based approach won't work in modern UWP, we need to implement a pure C# XMPP client.

2. Implement Message Formats: We'll need to reverse-engineer or recreate the Protocol Buffer message definitions.

3. Replace COM Dependencies: All COM-based components need to be replaced with pure C# implementations.


## ..
As is. No support. RnD it yourself.

## .
[M][E] Dec, 6 2025

![](/Images/footer.png)

