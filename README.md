# aDFC
## Adaptive Delayed Feedback Control in Neuronal Populations


This application allows the user to run the Adaptive Delayed Feedback Control (aDFC) algorithm to control neuronal populations with electrical stimulation.
We developed this application to conduct the experiments for the publication: *"Disrupting abnormal neuronal oscillations with adaptive delayed feedback control"*, under review

doi: https://doi.org/10.1101/2022.07.05.498735

Domingos Leite de Castro, Miguel Aroso, A. Pedro Aguiar, David B. Grayden, Paulo Aguiar

![alt text](https://github.com/NCN-Lab/aDFC/blob/main/app.png)

The C# application runs on a Windows computer connected to the MEA2100-256 System from MultiChannel Systems (MCS). 

To run the application you must:
- Download the software Multi Channel Experimenter from MCS (it was tested with version 2.19.0.21354)
- Connect both USB-A and USB-B ports from MEA2100-256 System Interface Board to the computer
- run aDFC_app.exe

  
The app was designed to be used simultaneously with Multi Channel Experimenter. The stimulus waveform must be downloaded in Multi Channel Experimenter and the stimulation will be triggered by the aDFC app, once the online code is running.
Multi Channel Experimenter can be used to record the neuronal data and visualize it in real-time, concurrently with the aDFC app. This app can also be used to run the non-adaptive DFC algorithm and random Poisson stimulation.


For questions, suggestions, and bug reports send an email to pauloaguiar@i3s.up.pt


THIS SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
