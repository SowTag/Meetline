import { createFileRoute, Outlet } from '@tanstack/react-router'
import { useQuery } from '@tanstack/react-query'
import { getCurrentUserOptions } from '#/client/@tanstack/react-query.gen.ts'
import { Button } from '#/components/ui/button'
import {
  ResizableHandle,
  ResizablePanel,
  ResizablePanelGroup,
} from '#/components/ui/resizable'

export const Route = createFileRoute('/_authenticated/_sidebar/chats')({
  component: RouteComponent,
})

function RouteComponent() {
  return (
    <ResizablePanelGroup>
      <ResizablePanel
        minSize={'25%'}
        defaultSize={'40%'}
        collapsible
      >
        Chat list
      </ResizablePanel>

      <ResizableHandle />

      <ResizablePanel>
        <Outlet />
      </ResizablePanel>
    </ResizablePanelGroup>
  )
}
